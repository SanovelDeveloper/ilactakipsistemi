using Functions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeclarationServices
{
    public class SendProductionTest
    {
        public SendProductionTest(int AUsrId, char AEnvironment, string AConnectionString)
        {
            Global.UsrId = AUsrId;
            Global.Environment = AEnvironment;
            Global.ConnectionString = AConnectionString;
            Global.Settings = new Settings(AEnvironment);
        }
        private int iHareketParentID = 0;
        private string _token;
        private DateTime _tokenExpiration;
        public async Task<int> InitializeProductionDeclaration(int KayitAdedi, string UretimEmriNo)
        {
            try
            {
                iHareketParentID = 0;
                int iDonguAdedi = (KayitAdedi / Global.Settings.DeclarationCount);
                if (Convert.ToDouble(KayitAdedi) / Convert.ToDouble(Global.Settings.DeclarationCount) != iDonguAdedi) iDonguAdedi++;



                // 10000'lik verilerin olduğu listeyi simüle ediyoruz.
                var dataList = Enumerable.Range(1, 10000).ToList();

                // 1000'lik paketler oluşturuyoruz.
                var chunkedData = dataList
                    .Select((item, index) => new { item, index })
                    .GroupBy(x => x.index / 1000)
                    .Select(group => group.Select(x => x.item).ToList())
                    .ToList();

                // Tüm paketleri asenkron olarak işleyelim.
                bool allSuccessful = await ProcessAllPackagesAsync(chunkedData);

                // Tüm gönderimler bittiğinde sonuçları kontrol edelim.
                if (allSuccessful)
                {
                    Console.WriteLine("Tüm paketler başarıyla gönderildi.");
                }
                else
                {
                    Console.WriteLine("Bazı paketler başarısız oldu.");
                }

                // Program diğer işlemlere devam edebilir.
                Console.WriteLine("Program diğer kodlara devam edebilir.");

                return iHareketParentID;
            }
            catch
            {
                throw;
            }
        }

        // Tüm paketleri işleyen ana metod
        static async Task<bool> ProcessAllPackagesAsync(List<List<int>> chunkedData)
        {
            List<Task<bool>> tasks = new List<Task<bool>>();

            foreach (var package in chunkedData)
            {
                // Asenkron olarak her paketi işliyoruz ve sonucunu takip ediyoruz.
                tasks.Add(SendPackageWithRetryAsync(package));
            }

            // Tüm gönderimlerin tamamlanmasını bekliyoruz.
            bool[] results = await Task.WhenAll(tasks);

            // Eğer tüm sonuçlar true ise, tüm gönderimler başarılı olmuş demektir.
            return results.All(r => r);
        }

        // Her paketi API'ye gönderir ve hatalı olanları tekrar gönderir.
        static async Task<bool> SendPackageWithRetryAsync(List<int> package)
        {
            int retryCount = 0;
            bool success = false;

            while (retryCount < 3 && !success)
            {
                try
                {
                    // API'ye asenkron gönderim.
                    await SendToApiAsync(package);
                    success = true; // Başarılı olduysa, döngüden çık.
                }
                catch (Exception ex)
                {
                    // Hata durumunda tekrar denemek için retryCount artırıyoruz.
                    retryCount++;
                    Console.WriteLine($"Gönderim hatası: {ex.Message}. Tekrar deneniyor ({retryCount}/3)");
                    await Task.Delay(1000); // Her denemeden sonra kısa bir bekleme süresi
                }
            }

            if (!success)
            {
                Console.WriteLine("Paket 3 denemeden sonra gönderilemedi.");
            }

            return success; // Başarıyla gönderilip gönderilmediğini geri döndürüyoruz.
        }

        // Bu metod API'ye veri gönderimini simüle eder.
        // Gerçek senaryoda burası HTTP isteği yapacak şekilde düzenlenmeli.
        static async Task SendToApiAsync(List<int> package)
        {
            // Burada API çağrısı yapılacak. Örnek olarak bir hata atılabilir.
            await Task.Delay(500); // API'nin cevap süresini simüle etmek için kısa bir bekleme.

            // Bazen hataya düşecek şekilde simüle ediliyor.
            if (new Random().Next(0, 3) == 0) // %33 hata olasılığı
            {
                throw new Exception("Simüle edilen hata.");
            }

            Console.WriteLine("Paket başarıyla gönderildi.");
        }


        public async Task<string> GetTokenAsync(string sKullaniciAdi, string sSifre)
        {
            if (IsTokenExpired())
            {
                using (var client = new HttpClient())
                {
                    var url = Global.Settings.Services.Token;
                    JObject oJsonObject = new JObject
                    {
                        { "username", sKullaniciAdi },
                        { "password", sSifre }
                    };

                    var response = await client.PostAsync(url, new StringContent(oJsonObject.ToString(), Encoding.UTF8, "application/json"));
                    response.EnsureSuccessStatusCode(); // İsteğin başarılı olduğunu doğrular.

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var tokenData = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);

                    _token = tokenData["token"].ToString();
                    _tokenExpiration = GetTokenExpiration(tokenData); // Token expiration süresi ayarlanıyor
                }
                return _token;
            }

            return _token; 
        }

        private bool IsTokenExpired()
        {
            return string.IsNullOrEmpty(_token) || DateTime.UtcNow >= _tokenExpiration;
        }
        private DateTime GetTokenExpiration(Dictionary<string, object> tokenData)
        {
            // Genelde token içinde "exp" adında bir alan bulunur, Unix epoch formatında bir tarih içerir
            if (tokenData.TryGetValue("exp", out object expValue))
            {
                var expirationUnix = Convert.ToInt64(expValue);
                return DateTimeOffset.FromUnixTimeSeconds(expirationUnix).UtcDateTime;
            }

            // Eğer token içinde expiration bilgisi yoksa, varsayılan bir süre belirleyebiliriz (örneğin 1 saat)
            return DateTime.UtcNow.AddHours(1);
        }
    }
}
