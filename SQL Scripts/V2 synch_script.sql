USE [ITS]
GO

/*Script created by Toad for SQL Server at 13.04.2012 08:47.
Please back up your database before running this script.*/

PRINT N'Synchronizing objects from ITS to ITS'

SET NUMERIC_ROUNDABORT, IMPLICIT_TRANSACTIONS OFF
SET ANSI_PADDING, ANSI_NULLS, QUOTED_IDENTIFIER, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, XACT_ABORT ON
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO

BEGIN TRANSACTION
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[File_List] (
	[fle_file_name] nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[fle_md5] char(32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	PRIMARY KEY ([fle_file_name] ASC) WITH (FILLFACTOR=100) ON [PRIMARY]
)
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_Production_Data_From_AGE]
/*
{******************************************************************************}
{  Amaç         : AGE veritabanından üretim verilerinin aktarılması.           }
{																										 }
{  Param. Gelen :                                                          	 }
{																										 }
{  Açıklama     : Bu blok daha önce Get_Data_From_WMS SP'sinin içerisinde idi. }
{                 Oradan kaldırılarak bu yeni SP oluşturuldu.                  }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     03/02/2012  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
AS
	INSERT INTO Package_List
         (pck_code,
          pck_order_id,
          pck_status_id,
          pck_device_id,
          pck_cell_id,
          pck_timestamp,
          pck_is_filled,
          pck_original_order_id,
          pck_was_printed,
          pck_source)
	SELECT URUN_SIRANO,
	       CASE 
            WHEN PATINDEX('%[_]%', BILDIRIM_ACIKLAMA) > 0 THEN SUBSTRING(BILDIRIM_ACIKLAMA, 1, PATINDEX('%[_]%', BILDIRIM_ACIKLAMA) - 1)
            ELSE BILDIRIM_ACIKLAMA
          END,
	       CASE URUN_DAMAGE
	         WHEN 0 THEN 10
	         ELSE 20
	       END,
	       NULL,
	       NULL,
	       BILDIRIM_OLUSTURMA_TARIH,
	       -1,
	       BILDIRIM_ACIKLAMA,
	       1,
	       'AGE'
	FROM KAREKOD.dbo.vwBEKLEYENBILDIRIMLER KAR
	LEFT JOIN Package_List PCK ON (PCK.pck_code COLLATE database_default = KAR.URUN_SIRANO)
	WHERE CASE 
            WHEN PATINDEX('%[_]%', BILDIRIM_ACIKLAMA) > 0 THEN SUBSTRING(BILDIRIM_ACIKLAMA, 1, PATINDEX('%[_]%', BILDIRIM_ACIKLAMA) - 1)
            ELSE BILDIRIM_ACIKLAMA
          END IN (SELECT ord_order_id COLLATE database_default FROM Order_List)
     AND PCK.pck_id IS NULL          
	  --AND URUN_SIRANO NOT IN (SELECT pck_code COLLATE database_default FROM Package_List)
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_Production_Data_From_TTSV1]
/*
{******************************************************************************}
{  Amaç         : TTS V1 veritabanından üretim verilerinin aktarılması.        }
{																										 }
{  Param. Gelen :                                                          	 }
{																										 }
{  Açıklama     : Bu blok daha önce Get_Data_From_WMS SP'sinin içerisinde idi. }
{                 Oradan kaldırılarak bu yeni SP oluşturuldu.                  }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     03/02/2012  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
AS
	INSERT INTO Order_List
         (ord_order_id,
          ord_batch_no,
          ord_sequence_order,
          ord_order_type,
          ord_order_status_id,
          ord_line_id,
          ord_mmr_id,
          ord_target_quantity,
          ord_item_type_id,
          ord_order_start_date,
          ord_order_end_date,
          ord_expiry_date,
          ord_code_order_id,
          ord_phase)
	SELECT TB022_ORDER_ID,          
	       ISNULL(TB022_PK_BATCH_NO, TB022_ORDER_ID),
      	 MAX(TB022_SEQUENCE_ORDER),
      	 TB022_ORDER_TYPE,
      	 TB022_ORDER_STATUS_ID,
      	 TB022_LINE_ID,
      	 mmr_id,
      	 MAX(TB022_TARGET_QTY),
      	 TB022_UOM_TARGET_ID,
          ISNULL(MAX(TB022_REAL_START_DATE), GETDATE()),
      	 MAX(TB022_REAL_END_DATE),
      	 MAX(TB022_EXPIRY_DATE),
      	 MAX(TB022_CODE_ORDER_ID),
          1
   FROM TTS.TTS.dbo.TB022_TTORDERS 
   INNER JOIN TTS.TTS.dbo.TB020_ITEM_MASTER ON (TB020_ITEM_ID = TB022_ITEM_ID)
   INNER JOIN Material_Master ON (mmr_gtin = TB020_GTIN)
   WHERE TB022_ORDER_ID NOT IN (SELECT ord_order_id FROM Order_List)
     AND (CASE 
            WHEN PATINDEX('%[_]%', TB022_ORDER_ID) > 0 THEN SUBSTRING(TB022_ORDER_ID, 1, PATINDEX('%[_]%', TB022_ORDER_ID) - 1)
            ELSE TB022_ORDER_ID
          END > '10000' 
       OR CASE 
            WHEN PATINDEX('%[_]%', TB022_ORDER_ID) > 0 THEN SUBSTRING(TB022_ORDER_ID, 1, PATINDEX('%[_]%', TB022_ORDER_ID) - 1)
            ELSE TB022_ORDER_ID
          END BETWEEN 1000 AND 9999)    
     AND TB022_ORDER_ID <> '28275'         
	GROUP BY TB022_ORDER_ID,
            ISNULL(TB022_PK_BATCH_NO, TB022_ORDER_ID),
      	   TB022_ORDER_TYPE,
      	   TB022_ORDER_STATUS_ID,
      	   TB022_LINE_ID,
      	   mmr_id,     
            TB022_UOM_TARGET_ID
   ORDER BY TB022_ORDER_ID

	INSERT INTO Package_List
         (pck_code,
          pck_order_id,
          pck_status_id,
          pck_device_id,
          pck_cell_id,
          pck_timestamp,
          pck_is_filled,
          pck_original_order_id,
          pck_was_printed,
          pck_source)
	SELECT TB028_CODE,
          CASE 
            WHEN PATINDEX('%[_]%', TB028_ORDER_ID) > 0 THEN SUBSTRING(TB028_ORDER_ID, 1, PATINDEX('%[_]%', TB028_ORDER_ID) - 1)
            ELSE TB028_ORDER_ID
          END,	
	       TB028_USC_STATUS_ID,
	       TB028_DEVICE_ID,
	       TB028_CELL_ID,
	       TB028_TIMESTAMP,
	       TB028_IS_FILLED,
	       TB028_ORDER_ID,
	       1,
	       'TTS'
	FROM TTS.TTS.dbo.TB028_USC
	INNER JOIN TTS.TTS.dbo.TB022_TTORDERS ON (TB022_ORDER_ID = TB028_ORDER_ID)
	WHERE TB022_ORDER_STATUS_ID = 90
     AND TB028_CODE NOT IN (SELECT pck_code FROM Package_List)
     AND TB028_ORDER_ID <> '27478'
     
   UPDATE Order_List
   SET ord_order_status_id = TB022_ORDER_STATUS_ID
   FROM TTS.TTS.dbo.TB022_TTORDERS 
   WHERE ord_order_id = TB022_ORDER_ID
     AND ord_order_status_id <> TB022_ORDER_STATUS_ID  
     AND ord_phase = 1
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Order_List_Browse_For_All_Orders] 
   @order_id VARCHAR(20)
/*
{******************************************************************************}
{  Amaç         : İlgili üretim emrine bağlı tüm üretim emirlerini listelemek  }
{																										 }
{  Param. Gelen :                                                          	 }
{																										 }
{  Açıklama     :                                                              }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     07/02/2012  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/ 
AS
   SELECT ORD.ord_order_id AS order_id,
          ISNULL((SELECT COUNT(pck_id)
                  FROM Package_List
                  WHERE pck_original_order_id = ORD.ord_order_id), 0) + 
          ISNULL((SELECT COUNT(pcp_id)
                  FROM Package_List_Not_Printed
                  WHERE pcp_order_id = ORD.ord_order_id
                    AND pcp_code NOT IN (SELECT pck_code FROM Package_List WHERE pck_original_order_id = ORD.ord_order_id)), 0) AS created_usc_count, 
          CAST(ISNULL((SELECT COUNT(pck_id)
                       FROM Package_List
                       WHERE pck_original_order_id = ORD.ord_order_id
                         AND pck_status_id = 10), 0) AS VARCHAR) + ' (' + 
          CAST(ISNULL((SELECT COUNT(pck_id)
                       FROM Package_List
                       WHERE pck_original_order_id = ORD.ord_order_id
                         AND pck_status_id <> 10), 0) AS VARCHAR) + ')' AS package_count,          
          ISNULL((SELECT COUNT(pcp_id)
                  FROM Package_List_Not_Printed
                  WHERE pcp_order_id = ORD.ord_order_id
                    AND pcp_code NOT IN (SELECT pck_code FROM Package_List WHERE pck_original_order_id = ORD.ord_order_id)), 0) AS diff,
          (SELECT ors_order_status_description
           FROM Order_Status
           WHERE ors_order_status_id = ORD.ord_order_status_id
             AND ors_phase = ORD.ord_phase) AS order_status                    
   FROM Order_List ORD
   WHERE ord_order_id LIKE @order_id + '%'
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_And_SSCC_Search]
   @gtin     VARCHAR(14),  
   @pck_code VARCHAR(32),
   @sscc     VARCHAR(20)
AS
/*
{******************************************************************************}
{  Amaç         : Ambalaj kodundan ambalajın ya da sscc kodundan sscc icindeki }
{                 tüm ambalajların listelenmesi                                }
{																										 }
{  Param. Gelen : gtin (Ambalaj GTIN Numarası)                                 }
{                 pck_code (Ambalaj Kodu)                                      }
{                 sscc (SSCC Kodu)                                             }
{																										 }
{  Açıklama     :                       													 }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     22/02/2012  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
   IF @sscc IS NULL
   BEGIN
      SELECT PCK.pck_id
      FROM Package_List PCK
      INNER JOIN Order_List ORD ON (ORD.ord_order_id = PCK.pck_order_id)
      INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id)   
      INNER JOIN Package_Status PST ON (PST.pst_status_id = PCK.pck_status_id)
      WHERE PCK.pck_code = @pck_code
        AND MMR.mmr_gtin = @gtin
   END
   ELSE
   BEGIN
      SELECT PCK.pck_id
      FROM Package_List PCK
      INNER JOIN Package_Aggregations PAG ON (PAG.pag_pck_id = PCK.pck_id)
      WHERE PAG.pag_sscc = @sscc
   END
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_List_Browse_For_Production_Detail]
   @mmr_item_no VARCHAR(35),
   @batch_no    VARCHAR(20),
   @status      CHAR(1) = NULL,
   @status_id   TINYINT = NULL,
   @pck_code    VARCHAR(32) = '',      
   @usr_id      INT = NULL,
   @rowcount    INT = 100   
WITH RECOMPILE   
/*
{******************************************************************************}
{  Amaç         : Malzeme ve seri bazında ambalaj detaylarını listelemek       }
{																										 }
{  Param. Gelen :                                                          	 }
{																										 }
{  Açıklama     :                                                              }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     06/02/2012  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/   
AS
   DECLARE @Order_List TABLE (ord_order_id VARCHAR(20))
   
   INSERT INTO @Order_List
   SELECT ORD.ord_order_id   
   FROM Order_List ORD
   INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id)      
   WHERE ORD.ord_batch_no = @batch_no
     AND (@mmr_item_no IS NULL OR MMR.mmr_item_no = @mmr_item_no)
     
   SELECT TOP (@rowcount)
          CAST(0 AS BIT) AS checked,
          pck_order_id,
          pck_id,
          pck_code,
          pck_status_id,
          PST.pst_description,
          CASE pck_status
            WHEN 'W' THEN N'Beklemede'
            WHEN 'P' THEN N'Üretim Bildirimi Yapıldı'
            WHEN 'D' THEN N'Deaktive Edildi'
            WHEN 'S' THEN N'Satıldı'
            WHEN 'I' THEN N'İhracat Yapıldı'
          END AS status,
          ISNULL(dbo.TRK(dbo.Fn_Sifre_Coz(USR.usr_full_name)), 'TTS') AS inserted_user,
          pck_original_order_id,
          CASE pck_was_printed
            WHEN 0 THEN N'Basılmadı'
            WHEN 1 THEN N'Basıldı'
          END AS was_printed,
          ISNULL(pck_source, N'ELLE GİRİŞ') AS pck_source,
          pck_sscc
   FROM Package_List PCK
   INNER JOIN Package_Status PST ON (PST.pst_status_id = PCK.pck_status_id)
   LEFT JOIN WMSDEV.SECURITY.dbo.Users USR ON (USR.usr_id = PCK.pck_usr_id)
   WHERE pck_order_id IN (SELECT ord_order_id FROM @Order_List)
     AND (@status IS NULL OR pck_status = @status)
     AND (@status_id IS NULL OR pck_status_id = @status_id)
     AND (@usr_id IS NULL OR pck_usr_id = @usr_id)
     AND (@pck_code = '' OR pck_code LIKE '\' + @pck_code + '%' ESCAPE '\' ) 
   ORDER BY pck_code
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_List_Not_Printed_Browse_For_Production_Detail] 
   @mmr_item_no VARCHAR(35),
   @batch_no    VARCHAR(20)
/*
{******************************************************************************}
{  Amaç         : Malzeme ve seri bazında ambalaj detaylarını listelemek       }
{																										 }
{  Param. Gelen :                                                          	 }
{																										 }
{  Açıklama     :                                                              }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     06/02/2012  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/      
AS
   DECLARE @Order_List TABLE (ord_order_id VARCHAR(20))
   
   INSERT INTO @Order_List
   SELECT ORD.ord_order_id   
   FROM Order_List ORD
   INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id)      
   WHERE ORD.ord_batch_no = @batch_no
     AND (@mmr_item_no IS NULL OR MMR.mmr_item_no = @mmr_item_no)
     
   SELECT CAST(0 AS BIT) AS checked,
          *
   FROM Package_List_Not_Printed
   WHERE CASE 
            WHEN PATINDEX('%[_]%', pcp_order_id) > 0 THEN SUBSTRING(pcp_order_id, 1, PATINDEX('%[_]%', pcp_order_id) - 1)
            ELSE pcp_order_id
         END IN (SELECT ord_order_id FROM @Order_List)
     AND pcp_code NOT IN (SELECT pck_code FROM Package_List WHERE pck_order_id IN (SELECT ord_order_id FROM @Order_List))
   ORDER BY pcp_order_id
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_List_Update_First_Status]
   @order_id VARCHAR(20)
/*
{******************************************************************************}
{  Amaç         : Üretim emrine ait sonradan alınan ambalajların silinmesi ve  }
{                 durumlarının ilk haline getirilmesi                          }
{																										 }
{  Param. Gelen : order_id (Üretim Emri Id)                                    }
{																										 }
{  Açıklama     :                       													 }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     08/02/2012  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
AS
   BEGIN TRY
      DELETE Package_List
      WHERE pck_order_id = @order_id
        AND pck_was_printed = 0
        AND pck_source = 'TTS'
        AND pck_status = 'W'
        
      UPDATE Package_List
      SET pck_status_id = pck_previous_status_id
      WHERE pck_order_id = @order_id
        AND pck_previous_status_id IS NOT NULL
        AND pck_status = 'W'
   END TRY
   BEGIN CATCH
      DECLARE @ERROR_MESSAGE NVARCHAR(2048)
      SET @ERROR_MESSAGE = ERROR_MESSAGE()
      RAISERROR(N'İşlem yapılamadı. Hata = %s', 16, 1, @ERROR_MESSAGE)            
   END CATCH
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_List_Update_For_All_Packages_Good]
   @order_id VARCHAR(20)
/*
{******************************************************************************}
{  Amaç         : Tüm ambalajların durumunu iyi durumda statüsüne getirmek     }
{																										 }
{  Param. Gelen : order_id (Üretim Emri Id)                                    }
{																										 }
{  Açıklama     :                       													 }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     22/02/2012  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
AS
   BEGIN TRY
      UPDATE Package_List
      SET pck_status_id = 10,
          pck_previous_status_id = CASE 
                                    WHEN pck_previous_status_id IS NULL THEN pck_status_id
                                    WHEN pck_previous_status_id = 10 THEN NULL
                                    ELSE pck_previous_status_id
                                   END
      WHERE pck_order_id = @order_id
        AND pck_status_id <> 10 
        AND pck_status = 'W'
   END TRY
   BEGIN CATCH
      DECLARE @ERROR_MESSAGE NVARCHAR(2048)
      SET @ERROR_MESSAGE = ERROR_MESSAGE()
      RAISERROR(N'İşlem yapılamadı. Hata = %s', 16, 1, @ERROR_MESSAGE)            
   END CATCH
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Production_Declaration_Detail_Report]
   @begin_date    DATETIME = NULL,
   @end_date      DATETIME = NULL,
   @item_name     VARCHAR(50) = NULL,
   @order_id      VARCHAR(20) = NULL
/*
{******************************************************************************}
{  Amaç         : Üretim emri bildirim miktarları raporunu oluşturmak          }
{																										 }
{  Param. Gelen :                                                          	 }
{																										 }
{  Açıklama     :                                                              }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     13/02/2012  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/   
AS
   
   SELECT @begin_date = CONVERT(DATETIME,(CONVERT(VARCHAR(10), @begin_date, 120)) + ' 00:00:01',120),
          @end_date = CONVERT(DATETIME,(CONVERT(VARCHAR(10), @end_date, 120)) + ' 23:59:59',120)


   SELECT ORD.ord_order_id,
          ORD.ord_batch_no,
          ORD.ord_expiry_date,
          MMR.mmr_item_no,
          dbo.TRK(MMR.mmr_item_name) AS mmr_item_name,          
          ISNULL((SELECT SUM(MOD.mod_quantity)
                  FROM WMSDEV.GENERAL.dbo.Movement_Detail MOD WITH (NOLOCK) 
                  WHERE CAST(MOD.mod_pom_id AS VARCHAR(20)) = ORD.ord_order_id
                    AND MOD.mod_movement_type = 4), 0) AS wms_production_quantity,                    
          COUNT(PCK.pck_id) AS its_production_quantity,
          ISNULL((SELECT SUM(MOD.mod_quantity)
                  FROM WMSDEV.GENERAL.dbo.Movement_Detail MOD WITH (NOLOCK) 
                  WHERE MOD.mod_mmr_id = MMR.mmr_id
                    AND MOD.mod_supplier_batch_number = ORD.ord_batch_no
                    AND MOD.mod_movement_type = 1
                    AND MOD.mod_movement_direction = 2
                    AND MOD.mod_sales_waybill_mom_id IS NOT NULL), 0) AS wms_sales_quantity                                                 
   FROM Order_List ORD
   INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id) 
   INNER JOIN Package_List PCK WITH (NOLOCK) ON (PCK.pck_order_id = ORD.ord_order_id AND PCK.pck_status_id = 10)
   WHERE ORD.ord_order_start_date BETWEEN ISNULL(@begin_date, ORD.ord_order_start_date) AND ISNULL(@end_date, ORD.ord_order_start_date)
     AND (ISNULL(@item_name, '') = '' OR MMR.mmr_item_name LIKE '\' + @item_name + '%' ESCAPE '\' )
     AND (ISNULL(@order_id, '') = '' OR ORD.ord_order_id LIKE '\' + @order_id + '%' ESCAPE '\' ) 
   GROUP BY ORD.ord_order_id,
            ORD.ord_batch_no,
            ORD.ord_expiry_date,
            MMR.mmr_id,
            MMR.mmr_item_no,
            dbo.TRK(MMR.mmr_item_name)
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Shipping_Order_Search]
   @package_code VARCHAR(32)
AS
/*
{******************************************************************************}
{  Amaç         : Sevkiyat iş emri aranması                                    }
{																										 }
{  Param. Gelen : package_code (Ambalaj Numarası)                              }
{																										 }
{  Açıklama     :                                                              }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     10/01/2012  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
   SELECT TOP 1 SOR.sor_order_number
   FROM Shipping_Order_List SOR
   INNER JOIN Shipping_Order_Details SOD ON (SOD.sod_sor_id = SOR.sor_id)
   INNER JOIN Package_Aggregations PAG ON (PAG.pag_sscc = SOD.sod_sscc)
   INNER JOIN Package_List PCK WITH (NOLOCK) ON (PCK.pck_id = PAG.pag_pck_id)
   WHERE PCK.pck_code LIKE '\' + @package_code + '%' ESCAPE '\'
      OR SOD.sod_sscc = @package_code
   ORDER BY SOR.sor_id DESC
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[WMS_Production_Order_Insert_To_TTSV2]
   @order_id    VARCHAR(20),
   @batch_no    VARCHAR(20),
   @line_id     INT,
   @gtin_no     VARCHAR(14),
   @quantity    INT,
   @start_date  DATETIME,
   @expiry_date DATETIME
   
AS
   INSERT INTO Order_List
         (ord_order_id,
          ord_batch_no,
          ord_sequence_order,
          ord_order_type,
          ord_order_status_id,
          ord_line_id,
          ord_mmr_id,
          ord_target_quantity,
          ord_item_type_id,
          ord_order_start_date,
          ord_order_end_date,
          ord_expiry_date,
          ord_code_order_id,
          ord_phase)
	SELECT @order_id,
	       @batch_no,
      	 NULL,
          'P',   
          10,   
          @line_id,   
      	 (SELECT mmr_id FROM Material_Master WHERE mmr_gtin = @gtin_no),
      	 @quantity,
      	 NULL,
          @start_date,   
          NULL,
          @expiry_date,   
          NULL,
          2

   IF @@ERROR <> 0 
   BEGIN
      RAISERROR('070102-DSI-0001 - TTS sunucusuna üretim emri kaydedilirken bir hata oluştu!', 16, 1)
      ROLLBACK TRANSACTION
      RETURN  
   END
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Get_Data_From_WMS]
/*
{******************************************************************************}
{  Amaç         : WMS veritabanından malzeme ve cari tanımlama verilerinin     }
{                 aktarılması.                                                 }
{																										 }
{  Param. Gelen :                                                          	 }
{																										 }
{  Açıklama     :                       													 }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     16/12/2009  AY       Başlandı.                                    }
{    1.1     03/02/2012  AY		 Üretim verilerinin aktarımı diğer SP'lere    }
{                                 taşındı.                                     }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
AS
   INSERT INTO Material_Master
   SELECT MMR.mmr_id,
          MMR.mmr_item_no,
          MMR.mmr_sanovel_material_name,
          '0' + MMM.mmm_barcode,
          CASE MMR.mmr_registered_to
            WHEN 618 THEN 0
            WHEN 500 THEN 1
            WHEN 498 THEN 2
          END,          
          DRG.drg_drug_group_description,
          1
   FROM WMSDEV.GENERAL.dbo.MMR_Manufacturer MMM
   INNER JOIN WMSDEV.GENERAL.dbo.Material_Master MMR ON (MMR.mmr_id = MMM.mmm_mmr_id)
   INNER JOIN WMSDEV.GENERAL.dbo.Drug_Group DRG ON (DRG.drg_drug_group_code = MMR.mmr_drug_group_code)
   LEFT JOIN Material_Master MMRI ON (MMRI.mmr_id = MMR.mmr_id)
   WHERE MMM.mmm_barcode <> ''   
     AND MMRI.mmr_id IS NULL
     
     
   INSERT INTO Account_Master
   SELECT AMR.amr_id,
          AMR.amr_account_code,
          AMR.amr_account_name,
          AMR.amr_gln_number,
          ADA.ada_gln_number
   FROM WMSDEV.GENERAL.dbo.Account_Master_Record AMR
   INNER JOIN WMSDEV.GENERAL.dbo.Account_Delivery_Address ADA ON (ADA.ada_amr_id = AMR.amr_id)
   LEFT JOIN Account_Master AMRI ON (AMRI.amr_id = AMR.amr_id)
   WHERE AMR.amr_gln_number IS NOT NULL
     AND ADA.ada_gln_number IS NOT NULL
     AND AMRI.amr_id IS NULL
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Order_List_Browse]
WITH EXEC AS CALLER
AS
--EXEC Get_Data_From_WMS
    
   SELECT *,
          CAST(0 AS BIT) AS checked,
          (SELECT TOP 1 SCH.sch_scheduled_time
           FROM Scheduled_Declaration SCH
           WHERE SCH.sch_order_id = ord_order_id
             AND SCH.sch_type = 'P'
             AND SCH.sch_status = 'W') AS scheduled_time
   FROM (SELECT ORD.ord_order_id,
                ORD.ord_batch_no,
                LIN.lin_description,
                MMR.mmr_item_no,
                dbo.TRK(MMR.mmr_item_name) AS mmr_item_name,
                MMR.mmr_gtin,
                ORD.ord_target_quantity,
                ORD.ord_order_start_date,
                ORD.ord_order_end_date,
                ORD.ord_expiry_date,
                (SELECT COUNT(pck_code)
                 FROM Package_List WITH (NOLOCK)
                 WHERE pck_order_id = ORD.ord_order_id
                   AND pck_status = 'W'
                   AND pck_status_id = 10) AS unsent_quantity,
                (SELECT COUNT(pck_code)
                 FROM Package_List WITH (NOLOCK)
                 WHERE pck_order_id = ORD.ord_order_id) AS total_package_quantity                         
         FROM Order_List ORD WITH (NOLOCK)
         INNER JOIN Material_Master MMR WITH (NOLOCK) ON (MMR.mmr_id = ORD.ord_mmr_id) 
         INNER JOIN Line_List LIN WITH (NOLOCK) ON (LIN.lin_id = ORD.ord_line_id)) T
   WHERE T.unsent_quantity > 0
   ORDER BY ord_order_id --DESC
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Order_List_Browse_For_Additional_Production_Order_Insert] --7, null, 2
   @day      INT = NULL,
   @order_id VARCHAR(20) = NULL,
   @phase    TINYINT = 1
AS   
   IF @phase = 1
   BEGIN
   	SELECT TB022_ORDER_ID,
   	       mmr_item_no,
   	       dbo.TRK(mmr_item_name) AS mmr_item_name,
   	       mmr_gtin,
   	       TB022_TARGET_QTY,
   	       TB022_PK_BATCH_NO, 
   	       TB022_EXPIRY_DATE,
             TB022_REAL_START_DATE,
             (SELECT COUNT(TB022_ORDER_ID) + 1
              FROM TTS.TTS.dbo.TB022_TTORDERS 
              WHERE TB022_ORDER_ID LIKE TTO.TB022_ORDER_ID + '%') AS count_of_order
      FROM TTS.TTS.dbo.TB022_TTORDERS TTO
      INNER JOIN TTS.TTS.dbo.TB020_ITEM_MASTER ON (TB020_ITEM_ID = TB022_ITEM_ID)
      INNER JOIN Material_Master ON (mmr_gtin = TB020_GTIN)
      WHERE TB022_ORDER_STATUS_ID NOT IN (50)
        AND TB022_REAL_START_DATE > GETDATE() - ISNULL(@day, 730)
        AND TB022_ORDER_ID = ISNULL(@order_id, TB022_ORDER_ID)
        AND TB022_ORDER_ID NOT LIKE '%[_]%'
   	ORDER BY TB022_ORDER_ID
	END
   ELSE IF @phase = 2
   BEGIN
      DECLARE @TEMP_ORDER_LIST TABLE (ORDER_ID	         VARCHAR(20),
                                      BATCH_NO	         VARCHAR(20),
                                      CREATION_TIMESTAMP	DATETIME,
                                      LINE_ID	         INT,
                                      ORDER_STATUS_ID	   INT,
                                      COUNTRY_ID	      VARCHAR(3),
                                      TARGET_ITEM_ID	   INT,
                                      TARGET_QTY	      INT,
                                      INTERNAL_CODE	   VARCHAR(30),
                                      LOWEST_ITEM_ID	   INT,
                                      HIGHEST_ITEM_ID	   INT,
                                      SCHED_TIMESTAMP	   DATETIME,
                                      EXEC_TIMESTAMP	   DATETIME,
                                      CLOSED_TIMESTAMP	DATETIME,
                                      EXPIRY_TIMESTAMP	DATETIME)



      IF @day IS NULL
      BEGIN
         INSERT INTO @TEMP_ORDER_LIST
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Production_Order_Data_From_TTS @order_id, NULL, NULL
         
         DECLARE @I INT,
                 @O VARCHAR(30)
                 
         SET @I = 2
         WHILE 1 = 1
         BEGIN
            SET @O = @order_id + '_' + CAST(@I AS VARCHAR)
            INSERT INTO @TEMP_ORDER_LIST
            EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Production_Order_Data_From_TTS @O, NULL, NULL            
            
            IF @@ROWCOUNT = 0 BREAK
            
            SET @I = @I + 1
         END
         
         
      END
      ELSE IF @order_id IS NULL
      BEGIN
         DECLARE @D DATETIME
         SET @D = GETDATE() - @day
         INSERT INTO @TEMP_ORDER_LIST
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Production_Order_Data_From_TTS NULL, NULL, @D
      END
      
      SELECT TMP.ORDER_ID AS TB022_ORDER_ID,
   	       MMR.mmr_item_no,
   	       dbo.TRK(MMR.mmr_item_name) AS mmr_item_name,
   	       MMR.mmr_gtin,
   	       TMP.TARGET_QTY AS TB022_TARGET_QTY,
   	       TMP.BATCH_NO AS TB022_PK_BATCH_NO, 
   	       TMP.EXPIRY_TIMESTAMP AS TB022_EXPIRY_DATE,
             TMP.SCHED_TIMESTAMP AS TB022_REAL_START_DATE,
             (SELECT COUNT(ORDER_ID) + 1
              FROM @TEMP_ORDER_LIST
              WHERE ORDER_ID LIKE TMP.ORDER_ID + '%') AS count_of_order      
      FROM @TEMP_ORDER_LIST TMP
      INNER JOIN Material_Master MMR ON (MMR.mmr_item_no = TMP.INTERNAL_CODE)
      WHERE TMP.ORDER_STATUS_ID NOT IN (110, 120)
        AND TMP.ORDER_ID NOT LIKE '%[_]%'
      
   END
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Package_List_Delete] 
   @pck_id    INT,
   @operation CHAR(1) = 'U'
AS
   IF @operation = 'U'
   BEGIN
      EXEC Package_List_Update @pck_id, 99
   END
   ELSE IF @operation = 'D'
   BEGIN
      IF EXISTS(SELECT 1
                FROM Package_List
                WHERE pck_id = @pck_id
                  AND (pck_usr_id IS NULL OR pck_usr_id = 0))
      BEGIN
         RAISERROR('070103-DSD-0003 - TTS sisteminden gelen ambalaj bilgisi silinemez!', 16, 1)
         RETURN      
      END                  
      
      IF EXISTS(SELECT 1
                FROM Package_List
                WHERE pck_id = @pck_id
                  AND pck_status <> 'W')
      BEGIN
         RAISERROR('070103-DSD-0004 - Bildirim durumu değişmiş bir ambalaj silinemez!', 16, 1)
         RETURN            
      END
            
      DELETE Package_List
      WHERE pck_id = @pck_id
      
      IF @@ERROR <> 0 OR @@ROWCOUNT = 0
      BEGIN
         RAISERROR('070103-DSD-0005 - Ambalaj detay bilgisi silinemedi!', 16, 1)
         RETURN
      END   
   END
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Package_List_Insert] 
   @pck_order_id  VARCHAR(20),
   @pck_code      VARCHAR(32),
   @usr_id        INT,
   @pck_original_order_id VARCHAR(20) = NULL,
   @pck_source            VARCHAR(20) = NULL  
AS
   IF EXISTS(SELECT 1
             FROM Package_List
             WHERE pck_code = @pck_code)
   BEGIN
      RAISERROR('070103-DSI-0001 - Ambalaj numarası mevcut. Tekrar eklenemez!', 16, 1)
      RETURN
   END
             
   SET @pck_order_id = CASE 
                        WHEN PATINDEX('%[_]%', @pck_order_id) > 0 THEN SUBSTRING(@pck_order_id, 1, PATINDEX('%[_]%', @pck_order_id) - 1)
                        ELSE @pck_order_id
                       END
                     
   INSERT INTO Package_List
          (pck_order_id,
           pck_code,
           pck_status_id,         
           pck_timestamp,
           pck_is_filled,
           pck_sync_date,
           pck_status,
           pck_usr_id,
           pck_original_order_id,
           pck_source,
           pck_was_printed)
   VALUES (@pck_order_id,
           @pck_code,
           10,
           GETDATE(),
           -1,
           GETDATE(),
           'W',
           @usr_id,
           @pck_original_order_id,
           @pck_source,
           0)
   
   IF @@ERROR <> 0 
   BEGIN
      RAISERROR('070103-DSI-0002 - Ambalaj detay bilgisi eklenemedi!', 16, 1)
      RETURN
   END
   
   RETURN  SCOPE_IDENTITY()
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Package_List_Insert_From_Not_Printed_Packages]
   @order_ids  VARCHAR(2000),
   @usr_id     INT
AS
/*
{******************************************************************************}
{  Amaç         : Basılmayan ambalajların basılan listesine eklenmesi          }
{																										 }
{  Param. Gelen :                                                          	 }
{																										 }
{  Açıklama     :                       													 }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     07/02/2012  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
   DECLARE @I INT
   DECLARE @S VARCHAR(20)

   SET NOCOUNT ON 
   
	DECLARE @torder_ids TABLE (order_id VARCHAR(20))
   SET @I = 0
   SET @S = ''

   WHILE LEN(@order_ids) > @I
   BEGIN
      SET @I = @I + 1
      IF (SUBSTRING(@order_ids, @I, 1) = ',')
      BEGIN
         INSERT INTO @torder_ids
         SELECT @S
			SET @S=''
         CONTINUE
      END
      SET  @S = @S + SUBSTRING(@order_ids, @I, 1)
   END

   SET NOCOUNT OFF
         
   BEGIN TRY                  
      INSERT INTO Package_List
             (pck_order_id,
              pck_code,
              pck_status_id,         
              pck_timestamp,
              pck_is_filled,
              pck_sync_date,
              pck_status,
              pck_usr_id,
              pck_original_order_id,
              pck_source,
              pck_was_printed)
      SELECT  CASE 
               WHEN PATINDEX('%[_]%', pcp_order_id) > 0 THEN SUBSTRING(pcp_order_id, 1, PATINDEX('%[_]%', pcp_order_id) - 1)
               ELSE pcp_order_id
              END,
              pcp_code,
              10,
              GETDATE(),
              -1,
              GETDATE(),
              'W',
              @usr_id,
              pcp_order_id,
              'TTS',
              0
      FROM Package_List_Not_Printed
      WHERE pcp_order_id IN (SELECT order_id FROM @torder_ids)
        AND pcp_code NOT IN (SELECT pck_code FROM Package_List WITH (NOLOCK) WHERE pck_original_order_id IN (SELECT order_id FROM @torder_ids))
      
      UPDATE Package_List
      SET pck_status_id = 10,
          pck_previous_status_id = CASE 
                                    WHEN pck_previous_status_id IS NULL THEN pck_status_id
                                    WHEN pck_previous_status_id = 10 THEN NULL
                                    ELSE pck_previous_status_id
                                   END      
      WHERE pck_original_order_id IN (SELECT order_id FROM @torder_ids)
        AND pck_status_id <> 10 
        AND pck_status = 'W'
      
   END TRY
   BEGIN CATCH
      RAISERROR('070103-DSI-0002 - Ambalajlar eklenirken bir sorun oluştu ve eklenemedi!', 16, 1)
      RETURN 
   END CATCH
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Package_Search]
   @pck_code VARCHAR(32) = '',
   @pck_sscc VARCHAR(20) = ''
AS
/*
{******************************************************************************}
{  Amaç         : Ambalaj kodunun aranması.                                    }
{																										 }
{  Param. Gelen : pck_code (Ambalaj Kodu)                                      }
{                 pck_sscc (SSCC Kodu)                                         }
{																										 }
{  Açıklama     :                       													 }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     09/02/2012  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
   SELECT ORD.ord_order_id,
          MMR.mmr_item_no + ' / ' + dbo.TRK(MMR.mmr_item_name) AS mmr_item_name,
          MMR.mmr_gtin,
          ORD.ord_batch_no,
          CONVERT(VARCHAR(10), ORD.ord_expiry_date, 120) AS expiry_date,
          CONVERT(VARCHAR(10), ORD.ord_expiry_date, 104) AS ord_expiry_date,
          PCK.pck_code,
          PCK.pck_status_id,
          PCK.pck_status,
          CASE pck_status
            WHEN 'W' THEN N'Beklemede'
            WHEN 'P' THEN N'Üretim Bildirimi Yapıldı'
            WHEN 'D' THEN N'Deaktive Edildi'
            WHEN 'S' THEN N'Satıldı'
            WHEN 'I' THEN N'İhracat Yapıldı'
          END AS status,   
          PST.pst_description,       
          PCK.pck_sync_date,
          PCK.pck_sscc
   FROM Package_List PCK WITH (NOLOCK)
   INNER JOIN Order_List ORD ON (ORD.ord_order_id = PCK.pck_order_id)
   INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id)   
   INNER JOIN Package_Status PST ON (PST.pst_status_id = PCK.pck_status_id)
   WHERE (@pck_code = '' OR PCK.pck_code LIKE @pck_code + '%')   
     AND (@pck_sscc = '' OR PCK.pck_sscc = @pck_sscc)
   UNION
   SELECT ORD.ord_order_id,
          MMR.mmr_item_no + ' / ' + dbo.TRK(MMR.mmr_item_name) AS mmr_item_name,
          MMR.mmr_gtin,
          ORD.ord_batch_no,
          CONVERT(VARCHAR(10), ORD.ord_expiry_date, 120) AS expiry_date,
          CONVERT(VARCHAR(10), ORD.ord_expiry_date, 104) AS ord_expiry_date,
          PCP.pcp_code AS pck_code,
          0 AS pck_status_id,
          ' ' AS pck_status,
          N'Basılmadı' AS status,
          '' AS pst_description,
          PCP.pcp_sync_date AS pck_sync_date,
          '' AS pck_sscc
   FROM Package_List_Not_Printed PCP WITH (NOLOCK)
   INNER JOIN Order_List ORD ON (ORD.ord_order_id = PCP.pcp_order_id)
   INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id)      
   WHERE PCP.pcp_code LIKE @pck_code + '%'     
     AND @pck_sscc = ''
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[WMS_Production_Order_Browse] 
AS
   SELECT POM.pom_id,
          POM.pom_production_start_date,
          MMR.mmr_id,
          MMR.mmr_item_no,
          dbo.TRK(CAST(MMR.mmr_sanovel_material_name AS NVARCHAR(50))) AS mmr_sanovel_material_name,
          POM.pom_supplier_batch_number,
          POM.pom_amount,
          ROUND(POM.pom_amount * (SELECT TOP 1 POS.pos_parameter
                                  FROM Production_Order_Insert_Settings POS
                                  WHERE POM.pom_amount >= POS.pos_min
                                    AND POM.pom_amount < POS.pos_max) / 1.05, 0) AS calculated_pom_amount,
          MMR.mmr_recipe_measure_unit_id,
          dbo.fn_get_expiry_date(POM.pom_id) AS expiry_date,
          (SELECT TOP 1 MMM.mmm_barcode
           FROM WMS.GENERAL.dbo.MMR_Manufacturer MMM
           WHERE MMM.mmm_mmr_id = MMR.mmr_id
             AND MMM.mmm_supplier_code IS NOT NULL
           ORDER BY MMM.mmm_barcode DESC) AS barcode,
          MMR.mmr_shelf_life           
   FROM WMS.GENERAL.dbo.Production_Order_Master POM
   INNER JOIN WMS.GENERAL.dbo.Material_Master MMR ON (MMR.mmr_id = POM.pom_mmr_id)
   INNER JOIN Material_Master MMRI ON (MMRI.mmr_item_no = MMR.mmr_item_no)
   LEFT JOIN WMS.GENERAL.dbo.Products_Countries_Relations PCR ON (PCR.pcr_mmr_id = MMR.mmr_id)
   LEFT JOIN WMS.GENERAL.dbo.Countries CNT ON (PCR.pcr_cnt_id = CNT.cnt_id)
   --LEFT JOIN TTS.TTS.dbo.TB022_TTORDERS ORD ON (ORD.TB022_ORDER_ID = CAST(POM.pom_id AS VARCHAR(20)))
   LEFT JOIN Order_List ORD ON (ORD.ord_order_id = CAST(POM.pom_id AS VARCHAR(20)))
   WHERE POM.pom_production_finished = 0
     AND POM.pom_cancellation_code = 0
     AND POM.pom_db_code = 4
     AND POM.pom_brn_code = 0
     AND POM.pom_production_type = 0
     AND MMR.mmr_category = 4
     AND ISNULL(CNT.cnt_countries_code, 'TR') = 'TR'
     --AND ORD.TB022_ORDER_ID IS NULL
     AND ORD.ord_order_id IS NULL
   ORDER BY POM.pom_id
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

EXECUTE [sp_addextendedproperty]
	@name = N'MS_Description',
	@value = N'Bildirim Zamanlama Id',
	@level0type = 'SCHEMA',
	@level0name = N'dbo',
	@level1type = 'TABLE',
	@level1name = N'Scheduled_Declaration',
	@level2type = 'COLUMN',
	@level2name = N'sch_id'
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

EXECUTE [sp_addextendedproperty]
	@name = N'MS_Description',
	@value = N'Üretim ya da Satış Numarası',
	@level0type = 'SCHEMA',
	@level0name = N'dbo',
	@level1type = 'TABLE',
	@level1name = N'Scheduled_Declaration',
	@level2type = 'COLUMN',
	@level2name = N'sch_order_id'
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

EXECUTE [sp_addextendedproperty]
	@name = N'MS_Description',
	@value = N'Tipi (P: Üretim, S: Satış, C: PTS, E: Ihracat)',
	@level0type = 'SCHEMA',
	@level0name = N'dbo',
	@level1type = 'TABLE',
	@level1name = N'Scheduled_Declaration',
	@level2type = 'COLUMN',
	@level2name = N'sch_type'
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

EXECUTE [sp_addextendedproperty]
	@name = N'MS_Description',
	@value = N'Bildirim Zamanı',
	@level0type = 'SCHEMA',
	@level0name = N'dbo',
	@level1type = 'TABLE',
	@level1name = N'Scheduled_Declaration',
	@level2type = 'COLUMN',
	@level2name = N'sch_scheduled_time'
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

EXECUTE [sp_addextendedproperty]
	@name = N'MS_Description',
	@value = N'Durumu (W: Beklemede, F: Tamamlandı)',
	@level0type = 'SCHEMA',
	@level0name = N'dbo',
	@level1type = 'TABLE',
	@level1name = N'Scheduled_Declaration',
	@level2type = 'COLUMN',
	@level2name = N'sch_status'
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

EXECUTE [sp_addextendedproperty]
	@name = N'MS_Description',
	@value = N'Bildirilen Zaman',
	@level0type = 'SCHEMA',
	@level0name = N'dbo',
	@level1type = 'TABLE',
	@level1name = N'Scheduled_Declaration',
	@level2type = 'COLUMN',
	@level2name = N'sch_declaration_time'
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

EXECUTE [sp_addextendedproperty]
	@name = N'MS_Description',
	@value = N'Eklenme Zamanı',
	@level0type = 'SCHEMA',
	@level0name = N'dbo',
	@level1type = 'TABLE',
	@level1name = N'Scheduled_Declaration',
	@level2type = 'COLUMN',
	@level2name = N'sch_created_time'
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

EXECUTE [sp_addextendedproperty]
	@name = N'MS_Description',
	@value = N'Ekleyen Kullanıcı',
	@level0type = 'SCHEMA',
	@level0name = N'dbo',
	@level1type = 'TABLE',
	@level1name = N'Scheduled_Declaration',
	@level2type = 'COLUMN',
	@level2name = N'sch_created_usr_id'
GO

IF @@ERROR <> 0 OR @@TRANCOUNT = 0 BEGIN IF @@TRANCOUNT > 0 ROLLBACK SET NOEXEC ON END
GO

IF @@TRANCOUNT>0 COMMIT TRANSACTION
GO

SET NOEXEC OFF