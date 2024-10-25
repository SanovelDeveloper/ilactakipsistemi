USE [ITS]
GO

/****** Object: Table [dbo].[Account_Master]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account_Master]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Account_Master]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Account_Master] (
	[amr_id] int NOT NULL,
	[amr_account_code] varchar(12) NULL,
	[amr_account_name] nvarchar(50) NULL,
	[amr_gln_number] char(13) NULL,
	[amr_branch_gln_number] char(13) NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Account_Master]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Account_Master]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Cancelled_Sales_Detail]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cancelled_Sales_Detail]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Cancelled_Sales_Detail]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cancelled_Sales_Detail] (
	[csd_id] int IDENTITY(1, 1),
	[csd_csm_id] int NOT NULL,
	[csd_pck_id] int NOT NULL,
	[csd_status] char(1) NOT NULL DEFAULT ('W'),
	[csd_creation_date] datetime NULL DEFAULT (getdate()),
	[csd_usr_id] int NOT NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Cancelled_Sales_Detail]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Cancelled_Sales_Detail]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Cancelled_Sales_Master]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cancelled_Sales_Master]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Cancelled_Sales_Master]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cancelled_Sales_Master] (
	[csm_id] int IDENTITY(1, 1),
	[csm_com_id] int NOT NULL,
	[csm_account_code] varchar(12) NOT NULL,
	[csm_document_number] nvarchar(20) NULL,
	[csm_creation_date] datetime NOT NULL DEFAULT (getdate()),
	[csm_usr_id] int NOT NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Cancelled_Sales_Master]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Cancelled_Sales_Master]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Case_Aggregations]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Case_Aggregations]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Case_Aggregations]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Case_Aggregations] (
	[cag_sscc] varchar(20) NOT NULL,
	[cag_parent_sscc] varchar(20) NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Case_Aggregations]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Case_Aggregations]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Companies]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Companies]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Companies]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Companies] (
	[com_id] tinyint NOT NULL,
	[com_company_name] nvarchar(100) NOT NULL,
	[com_gln_number] char(13) NOT NULL,
	[com_registered_to_id] tinyint NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Companies]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Companies]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Errors]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Errors]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Errors]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Errors] (
	[err_id] int IDENTITY(1, 1),
	[err_pmm_id] int NOT NULL,
	[err_error_message] varchar(100) NOT NULL,
	[err_datetime] smalldatetime NULL CONSTRAINT [DF_Errors_err_datetime] DEFAULT (getdate())
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Errors]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Errors]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Functions]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Functions]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Functions]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Functions] (
	[fun_id] smallint IDENTITY(1, 1) NOT FOR REPLICATION,
	[fun_description] varchar(70) NOT NULL,
	[fun_page_name] varchar(70) NOT NULL,
	[fun_is_active] tinyint NOT NULL,
	[fun_active_desc] varchar(50) NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Functions]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Functions]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Global_Error_List]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Global_Error_List]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Global_Error_List]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Global_Error_List] (
	[erl_id] int IDENTITY(1, 1),
	[erl_error_type] char(2) NOT NULL,
	[erl_error_code] char(5) NOT NULL,
	[erl_error_message] nvarchar(250) NOT NULL,
	[erl_error_description] nvarchar(250) NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Global_Error_List]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Global_Error_List]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Global_Settings]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Global_Settings]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Global_Settings]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Global_Settings] (
	[set_id] int IDENTITY(1, 1),
	[set_environment] char(1) NOT NULL,
	[set_setting_name] nvarchar(50) NOT NULL,
	[set_setting_variable] nvarchar(250) NOT NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Global_Settings]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Global_Settings]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Line_List]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Line_List]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Line_List]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Line_List] (
	[lin_id] int NOT NULL,
	[lin_description] varchar(30) NOT NULL,
	[lin_parent_lin_id] int NULL,
	[lin_type_id] int NULL,
	[lin_phase] tinyint NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Line_List]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Line_List]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Material_Master]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Material_Master]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Material_Master]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Material_Master] (
	[mmr_id] int NOT NULL,
	[mmr_item_no] varchar(35) NOT NULL,
	[mmr_item_name] varchar(50) NOT NULL,
	[mmr_gtin] varchar(14) NULL,
	[mmr_registered_to] tinyint NULL CONSTRAINT [DF_Material_Master_mmr_registered_to] DEFAULT ((0)),
	[mmr_drug_group] varchar(50) NULL,
	[mmr_is_active] tinyint NOT NULL CONSTRAINT [DF_Material_Master_mmr_is_active] DEFAULT ((1))
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Material_Master]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Material_Master]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Order_List]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order_List]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Order_List]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order_List] (
	[ord_order_id] varchar(20) NOT NULL,
	[ord_batch_no] varchar(20) NULL,
	[ord_sequence_order] int NULL,
	[ord_order_type] char(1) NOT NULL,
	[ord_order_status_id] tinyint NOT NULL,
	[ord_line_id] int NOT NULL,
	[ord_mmr_id] int NOT NULL,
	[ord_target_quantity] int NOT NULL,
	[ord_item_type_id] tinyint NULL,
	[ord_order_start_date] smalldatetime NULL,
	[ord_order_end_date] smalldatetime NULL,
	[ord_expiry_date] smalldatetime NOT NULL,
	[ord_code_order_id] int NULL,
	[ord_sync_date] smalldatetime NULL CONSTRAINT [DF_Order_List_ord_sync_date] DEFAULT (getdate()),
	[ord_phase] tinyint NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Order_List]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Order_List]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Order_Status]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order_Status]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Order_Status]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order_Status] (
	[ors_order_status_id] tinyint NOT NULL,
	[ors_order_status_description] varchar(30) NOT NULL,
	[ors_phase] tinyint NOT NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Order_Status]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Order_Status]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Package_Aggregations]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_Aggregations]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Package_Aggregations]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Package_Aggregations] (
	[pag_id] int IDENTITY(1, 1),
	[pag_pck_id] int NOT NULL,
	[pag_sscc] varchar(20) NOT NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Package_Aggregations]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Package_Aggregations]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Package_List]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_List]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Package_List]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Package_List] (
	[pck_id] int IDENTITY(1, 1),
	[pck_code] varchar(32) NOT NULL,
	[pck_order_id] varchar(20) NOT NULL,
	[pck_status_id] smallint NOT NULL,
	[pck_device_id] int NULL,
	[pck_cell_id] int NULL,
	[pck_timestamp] datetime NOT NULL,
	[pck_is_filled] smallint NOT NULL,
	[pck_sync_date] smalldatetime NULL CONSTRAINT [DF_Package_List_pck_sync_date] DEFAULT (getdate()),
	[pck_status] char(1) NULL CONSTRAINT [DF_Package_List_pck_status] DEFAULT ('W'),
	[pck_usr_id] int NULL CONSTRAINT [DF_Package_List_pck_usr_id] DEFAULT ((0)),
	[pck_previous_status_id] smallint NULL,
	[pck_original_order_id] varchar(20) NULL,
	[pck_was_printed] tinyint NULL,
	[pck_source] varchar(20) NULL,
	[pck_sscc] varchar(20) NULL,
	[pck_last_sold_account_code] varchar(12) NULL
) ON [ITS_PartitionScheme] ([pck_timestamp])
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Package_List]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Package_List]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Package_List_Log]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_List_Log]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Package_List_Log]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Package_List_Log] (
	[log_id] int IDENTITY(1, 1),
	[log_usr_id] int NULL,
	[log_datetime] datetime NOT NULL CONSTRAINT [DF_Package_List_Log_log_datetime] DEFAULT (getdate()),
	[log_operation] char(1) NOT NULL,
	[log_hostname] varchar(40) NULL,
	[log_program_name] varchar(100) NOT NULL,
	[log_pck_id] int NOT NULL,
	[log_pck_code] varchar(32) NULL,
	[log_old_status_id] smallint NOT NULL,
	[log_new_status_id] smallint NULL
) ON [ITS_PartitionScheme] ([log_datetime])
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Package_List_Log]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Package_List_Log]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Package_List_Not_Printed]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_List_Not_Printed]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Package_List_Not_Printed]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Package_List_Not_Printed] (
	[pcp_id] int IDENTITY(1, 1),
	[pcp_order_id] varchar(12) NOT NULL,
	[pcp_code] varchar(32) NOT NULL,
	[pcp_sync_date] datetime NULL CONSTRAINT [DF_Package_List_Not_Printed_pcp_sync_date] DEFAULT (getdate())
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Package_List_Not_Printed]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Package_List_Not_Printed]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Package_Movement_Detail]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_Movement_Detail]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Package_Movement_Detail]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Package_Movement_Detail] (
	[pmd_id] int IDENTITY(1, 1),
	[pmd_pmm_id] int NOT NULL,
	[pmd_pck_id] int NOT NULL,
	[pmd_datetime] smalldatetime NULL CONSTRAINT [DF_Package_Movement_Detail_pmd_datetime] DEFAULT (getdate()),
	[pmd_response_code] char(5) NOT NULL
) ON [ITS_PartitionScheme_smalldatetime] ([pmd_datetime])
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Package_Movement_Detail]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Package_Movement_Detail]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Package_Movement_Master]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_Movement_Master]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Package_Movement_Master]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Package_Movement_Master] (
	[pmm_id] int IDENTITY(1, 1),
	[pmm_key] varchar(20) NOT NULL,
	[pmm_order_id] varchar(20) NOT NULL,
	[pmm_type] char(1) NOT NULL,
	[pmm_parent_id] int NULL,
	[pmm_datetime] smalldatetime NULL CONSTRAINT [DF_Package_Movement_Master_pmm_datetime] DEFAULT (getdate()),
	[pmm_declaration_id] varchar(20) NULL,
	[pmm_sending_file_name] varchar(100) NULL,
	[pmm_coming_file_name] varchar(100) NULL,
	[pmm_usr_id] int NOT NULL,
	[pmm_environment] char(1) NOT NULL,
	[pmm_is_scheduled] bit NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Package_Movement_Master]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Package_Movement_Master]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Package_Status]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_Status]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Package_Status]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Package_Status] (
	[pst_status_id] tinyint NOT NULL,
	[pst_description] nvarchar(50) NOT NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Package_Status]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Package_Status]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Production_Order_Insert_Settings]   Script Date: 26.04.2012 10:07:46 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Production_Order_Insert_Settings]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Production_Order_Insert_Settings]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Production_Order_Insert_Settings] (
	[pos_id] int IDENTITY(1, 1),
	[pos_min] int NOT NULL,
	[pos_max] int NOT NULL,
	[pos_parameter] numeric(8, 5) NOT NULL,
	[pos_last_updated_usr_id] int NULL,
	[pos_last_updated_datetime] datetime NULL DEFAULT (getdate())
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Production_Order_Insert_Settings]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Production_Order_Insert_Settings]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Properties]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Properties]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Properties]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Properties] (
	[pro_name] varchar(20) NOT NULL,
	[pro_value] varchar(50) NOT NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Properties]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Properties]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Scheduled_Declaration]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Scheduled_Declaration]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Scheduled_Declaration]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Scheduled_Declaration] (
	[sch_id] int IDENTITY(1, 1),
	[sch_order_id] varchar(20) NOT NULL,
	[sch_type] char(1) NOT NULL,
	[sch_scheduled_time] datetime NOT NULL,
	[sch_status] char(1) NOT NULL DEFAULT ('W'),
	[sch_declaration_time] datetime NULL,
	[sch_created_time] datetime NULL DEFAULT (getdate()),
	[sch_created_usr_id] int NOT NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Scheduled_Declaration]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Scheduled_Declaration]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Shipping_Order_Details]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shipping_Order_Details]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Shipping_Order_Details]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Shipping_Order_Details] (
	[sod_id] int IDENTITY(1, 1),
	[sod_sor_id] int NOT NULL,
	[sod_sscc] varchar(20) NULL,
	[sod_pck_id] int NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Shipping_Order_Details]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Shipping_Order_Details]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Shipping_Order_List]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shipping_Order_List]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Shipping_Order_List]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Shipping_Order_List] (
	[sor_id] int IDENTITY(1, 1),
	[sor_order_number] nvarchar(20) NOT NULL,
	[sor_com_id] tinyint NULL,
	[sor_account_code] varchar(12) NULL,
	[sor_status] char(1) NULL,
	[sor_invoice_number] varchar(10) NULL,
	[sor_invoice_date] datetime NULL,
	[sor_creation_date] datetime NULL,
	[sor_completion_date] datetime NULL,
	[sor_was_declaration] tinyint NULL DEFAULT ((0)),
	[sor_pts_transfer_id] bigint NULL,
	[sor_pts_transfered_date] datetime NULL,
	[sor_transfer_again] tinyint NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Shipping_Order_List]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Shipping_Order_List]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[Transfer_Logs]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transfer_Logs]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[Transfer_Logs]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transfer_Logs] (
	[trl_id] int IDENTITY(1, 1),
	[trl_starting_time] datetime NULL DEFAULT (getdate()),
	[trl_finishing_time] datetime NULL,
	[trl_type] tinyint NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Transfer_Logs]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[Transfer_Logs]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Table [dbo].[User_Rights]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_Rights]') AND type ='U'))
BEGIN
	DROP TABLE [dbo].[User_Rights]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User_Rights] (
	[usr_id] int NOT NULL,
	[fun_id] smallint NOT NULL,
	[rgh_read] tinyint NOT NULL CONSTRAINT [DF_User_Rights_rgh_read] DEFAULT ((1)),
	[rgh_insert] tinyint NOT NULL CONSTRAINT [DF_User_Rights_rgh_insert] DEFAULT ((0)),
	[rgh_update] tinyint NOT NULL CONSTRAINT [DF_User_Rights_rgh_update] DEFAULT ((0)),
	[rgh_delete] tinyint NOT NULL CONSTRAINT [DF_User_Rights_rgh_delete] DEFAULT ((0)),
	[rgh_export] tinyint NOT NULL CONSTRAINT [DF_User_Rights_rgh_export] DEFAULT ((0)),
	[rgh_print] tinyint NOT NULL CONSTRAINT [DF_User_Rights_rgh_print] DEFAULT ((0)),
	[rgh_modification_date] datetime NOT NULL CONSTRAINT [DF_User_Rights_rgh_modification_date] DEFAULT (getdate()),
	[mdf_usr_id] int NOT NULL
) ON [PRIMARY]
WITH(DATA_COMPRESSION = NONE)
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[User_Rights]',
	@OptionName  = 'table lock on bulk load',
	@OptionValue  = 'OFF'
GO

EXECUTE [sp_tableoption]
	@TableNamePattern  = N'[dbo].[User_Rights]',
	@OptionName  = 'vardecimal storage format',
	@OptionValue  = 'OFF'
GO

/****** Object: Function [dbo].[TRK]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRK]') AND type IN ('FN', 'IF', 'IS', 'TF', 'FS', 'FT')))
BEGIN
	DROP FUNCTION [dbo].[TRK]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[TRK](@A NVARCHAR(4000))
RETURNS NVARCHAR(4000)  
AS 
BEGIN
  DECLARE @TMP NVARCHAR(4000) 
  SET @TMP = REPLACE(@A COLLATE LATIN1_GENERAL_BIN, CHAR(208), N'Ğ')
  SET @TMP = REPLACE(@TMP COLLATE LATIN1_GENERAL_BIN, CHAR(220), N'Ü')
  SET @TMP = REPLACE(@TMP COLLATE LATIN1_GENERAL_BIN, CHAR(222), N'Ş')
  SET @TMP = REPLACE(@TMP COLLATE LATIN1_GENERAL_BIN, CHAR(221), N'İ')
  SET @TMP = REPLACE(@TMP COLLATE LATIN1_GENERAL_BIN, CHAR(214), N'Ö')
  SET @TMP = REPLACE(@TMP COLLATE LATIN1_GENERAL_BIN, CHAR(199), N'Ç')
  SET @TMP = REPLACE(@TMP COLLATE LATIN1_GENERAL_BIN, CHAR(73), N'I')
  SET @TMP = REPLACE(@TMP COLLATE LATIN1_GENERAL_BIN, CHAR(240), N'ğ')
  SET @TMP = REPLACE(@TMP COLLATE LATIN1_GENERAL_BIN, CHAR(252), N'ü')
  SET @TMP = REPLACE(@TMP COLLATE LATIN1_GENERAL_BIN, CHAR(254), N'ş')
  SET @TMP = REPLACE(@TMP COLLATE LATIN1_GENERAL_BIN, CHAR(105), N'i')
  SET @TMP = REPLACE(@TMP COLLATE LATIN1_GENERAL_BIN, CHAR(246), N'ö')
  SET @TMP = REPLACE(@TMP COLLATE LATIN1_GENERAL_BIN, CHAR(231), N'ç')
  SET @TMP = REPLACE(@TMP COLLATE LATIN1_GENERAL_BIN, CHAR(253), N'ı')
  RETURN @TMP
END
GO

/****** Object: View [dbo].[vAccount_Master]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vAccount_Master]') AND type ='V'))
BEGIN
	DROP VIEW [dbo].[vAccount_Master]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vAccount_Master]
AS
   SELECT amr_id,
          amr_account_code,
          dbo.TRK(amr_account_name) AS amr_account_name,
          amr_gln_number,
          amr_branch_gln_number,
          amr_account_code + ' / ' + dbo.TRK(amr_account_name) AS account_name
   FROM Account_Master
GO

/****** Object: Function [dbo].[fn_get_expiry_date]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_get_expiry_date]') AND type IN ('FN', 'IF', 'IS', 'TF', 'FS', 'FT')))
BEGIN
	DROP FUNCTION [dbo].[fn_get_expiry_date]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_get_expiry_date] (
   @pom_id INT)  
RETURNS DATETIME
AS
BEGIN      
   DECLARE @expiry_date DATETIME
   SELECT @expiry_date = expiry_date
   FROM TESTTCP.GENERAL.dbo.vProduction_Order_Expiry_Dates
   WHERE pom_id = @pom_id

   /* 
      
   SELECT TOP 1 @expiry_date = MI.min_expiry_date--DATEADD(mm, MMR.mmr_shelf_life, MI.min_production_date)
   FROM TESTTCP.GENERAL.dbo.Production_Order_Master POM  
   INNER JOIN TESTTCP.GENERAL.dbo.Production_Order_Detail POD ON (POD.pod_pom_id = POM.pom_id)
   INNER JOIN TESTTCP.GENERAL.dbo.Material_Master MMR ON (MMR.mmr_id = POD.pod_mmr_id)       
   INNER JOIN TESTTCP.GENERAL.dbo.MMR_Manufacturer MMM ON (MMM.mmm_mmr_id = MMR.mmr_id)                               
   INNER JOIN TESTTCP.GENERAL.dbo.Material_Inventory MI ON (MI.min_mmm_id = MMM.mmm_id
                                                        AND MI.min_year = POM.pom_production_year
                                                        AND MI.min_batch_no = POM.pom_production_batch_number
                                                        AND MI.min_package_no = 1)
   WHERE POM.pom_id = @pom_id
     AND MMR.mmr_category = 2
     AND MMR.mmr_auto_create_production = 1
   */  
   -- Ayın son günü döndürülüyor.     
   RETURN DATEADD(d, -1, DATEADD(mm, DATEDIFF(m, 0, @expiry_date) + 1, 0))     
   
END
GO

/****** Object: Function [dbo].[fn_get_shipping_packages]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_get_shipping_packages]') AND type IN ('FN', 'IF', 'IS', 'TF', 'FS', 'FT')))
BEGIN
	DROP FUNCTION [dbo].[fn_get_shipping_packages]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_get_shipping_packages](@order_number NVARCHAR(20))
RETURNS @Shipping_Packages TABLE
   (gtin         VARCHAR(14),
    item_no      VARCHAR(35),
    batch_no     VARCHAR(20),
    package_id   INT)
/*
{******************************************************************************}
{  Amaç         : Sevkiyat iş emrinin detaylarının listelenmesi.               }
{																										 }
{  Param. Gelen : order_number (İş emri numarası)                              }
{																										 }
{  Açıklama     :                                                              }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     09/12/2011  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
AS
BEGIN
   DECLARE @level TINYINT 
   DECLARE @Csscc VARCHAR(20)
   
   SET @level = 0
     
   DECLARE @Shipping_Order_Details_Browse TABLE(parent_sscc  VARCHAR(20),
                                                package_sscc VARCHAR(20),
                                                gtin         VARCHAR(14),
                                                batch_no     VARCHAR(20),
                                                expiry_date  VARCHAR(10),
                                                package_code VARCHAR(32),
                                                package_id   INT,
                                                [level]      TINYINT)
                                                
   INSERT INTO @Shipping_Order_Details_Browse
   SELECT CAST(NULL AS VARCHAR(20)) AS parent_sscc,
          SOD.sod_sscc,
          MMR.mmr_gtin,
          ORD.ord_batch_no,
          CONVERT(VARCHAR(10), ORD.ord_expiry_date, 120) AS expiry_date,
          PCK.pck_code,
          PCK.pck_id,
          0 AS [level]
   FROM Shipping_Order_List SOR
   INNER JOIN Shipping_Order_Details SOD ON (SOD.sod_sor_id = SOR.sor_id)
   INNER JOIN Package_Aggregations PAG ON (PAG.pag_sscc = SOD.sod_sscc)      
   INNER JOIN Package_List PCK ON (PCK.pck_id = PAG.pag_pck_id)
   INNER JOIN Order_List ORD ON (ORD.ord_order_id = PCK.pck_order_id)
   INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id) 
   WHERE SOR.sor_order_number = @order_number
   
   BASLA:
   
   IF EXISTS(SELECT 1
             FROM Case_Aggregations CAG
             INNER JOIN @Shipping_Order_Details_Browse TMP ON (TMP.package_sscc = cag_parent_sscc)
             WHERE [level] = @level)
   BEGIN                            
      SET @level = @level + 1

      DECLARE cur_GET_CHILD_SSCC CURSOR FOR 
      SELECT DISTINCT
             package_sscc
      FROM @Shipping_Order_Details_Browse       
      WHERE [level] = @level - 1
      
      OPEN cur_GET_CHILD_SSCC
      FETCH NEXT FROM cur_GET_CHILD_SSCC 
      INTO @Csscc 
      
      WHILE @@FETCH_STATUS = 0
      BEGIN
      	INSERT INTO @Shipping_Order_Details_Browse  
         SELECT @Csscc,
                PAG.pag_sscc,
                MMR.mmr_gtin,
                ORD.ord_batch_no,
                CONVERT(VARCHAR(10), ORD.ord_expiry_date, 120) AS expiry_date,
                PCK.pck_code,
                PCK.pck_id,
                @level
         FROM Case_Aggregations CAG
         INNER JOIN Package_Aggregations PAG ON (PAG.pag_sscc = CAG.cag_sscc)      
         INNER JOIN Package_List PCK ON (PCK.pck_id = PAG.pag_pck_id)
         INNER JOIN Order_List ORD ON (ORD.ord_order_id = PCK.pck_order_id)
         INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id) 
         WHERE CAG.cag_parent_sscc = @Csscc
         
      	FETCH NEXT FROM cur_GET_CHILD_SSCC 
         INTO @Csscc 
      END
      
      CLOSE cur_GET_CHILD_SSCC
      DEALLOCATE cur_GET_CHILD_SSCC
   
      GOTO BASLA
   END
  
   INSERT INTO @Shipping_Packages
   SELECT AGG.gtin,
          MMR.mmr_item_no,
          AGG.batch_no,
          AGG.package_id
   FROM @Shipping_Order_Details_Browse AGG
   INNER JOIN Material_Master MMR ON (MMR.mmr_gtin = AGG.gtin)
            
   RETURN
END
GO

/****** Object: Function [dbo].[fn_get_shipping_packages_count_by_groups]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_get_shipping_packages_count_by_groups]') AND type IN ('FN', 'IF', 'IS', 'TF', 'FS', 'FT')))
BEGIN
	DROP FUNCTION [dbo].[fn_get_shipping_packages_count_by_groups]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_get_shipping_packages_count_by_groups](@order_numbers NVARCHAR(MAX))
RETURNS @Shipping_Packages TABLE
   (order_id     VARCHAR(20),
    gtin         VARCHAR(14),
    item_no      VARCHAR(35),
    batch_no     VARCHAR(20),
    quantity     INT)
/*
{******************************************************************************}
{  Amaç         : Sevkiyat iş emrinin detaylarının listelenmesi.               }
{																										 }
{  Param. Gelen : order_numbers (İş emri numaraları)                           }
{																										 }
{  Açıklama     :                                                              }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     15/02/2012  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
AS
BEGIN
   DECLARE @I INT
   DECLARE @S VARCHAR(20)
   
	DECLARE @order_ids TABLE (order_id VARCHAR(20))
   SET @I = 0
   SET @S = ''

   WHILE LEN(@order_numbers) > @I
   BEGIN
      SET @I = @I + 1
      IF (SUBSTRING(@order_numbers, @I, 1) = ',')
      BEGIN
         INSERT INTO @order_ids
         SELECT CAST(@S AS INT)
			SET @S=''
         CONTINUE
      END
      SET  @S = @S + SUBSTRING(@order_numbers, @I, 1)
   END
            
   DECLARE @level TINYINT 
   DECLARE @Csscc         VARCHAR(20),
           @Corder_number VARCHAR(20)
   
   SET @level = 0
     
   DECLARE @Shipping_Order_Details_Browse TABLE(order_number NVARCHAR(20),
                                                parent_sscc  VARCHAR(20),
                                                package_sscc VARCHAR(20),
                                                gtin         VARCHAR(14),
                                                item_no      VARCHAR(35),
                                                batch_no     VARCHAR(20),
                                                package_id   INT,
                                                [level]      TINYINT)
                                                
   INSERT INTO @Shipping_Order_Details_Browse
   SELECT SOR.sor_order_number,
          CAST(NULL AS VARCHAR(20)) AS parent_sscc,
          SOD.sod_sscc,
          MMR.mmr_gtin,
          MMR.mmr_item_no,
          ORD.ord_batch_no,
          PCK.pck_id,
          0 AS [level]
   FROM Shipping_Order_List SOR
   INNER JOIN Shipping_Order_Details SOD ON (SOD.sod_sor_id = SOR.sor_id)
   INNER JOIN Package_Aggregations PAG ON (PAG.pag_sscc = SOD.sod_sscc)      
   INNER JOIN Package_List PCK ON (PCK.pck_id = PAG.pag_pck_id)
   INNER JOIN Order_List ORD ON (ORD.ord_order_id = PCK.pck_order_id)
   INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id) 
   WHERE SOR.sor_order_number IN (SELECT order_id FROM @order_ids)
   
   BASLA:
   
   IF EXISTS(SELECT 1
             FROM Case_Aggregations CAG
             INNER JOIN @Shipping_Order_Details_Browse TMP ON (TMP.package_sscc = cag_parent_sscc)
             WHERE [level] = @level)
   BEGIN                            
      SET @level = @level + 1

      DECLARE cur_GET_CHILD_SSCC CURSOR FOR 
      SELECT DISTINCT
             order_number,
             package_sscc
      FROM @Shipping_Order_Details_Browse       
      WHERE [level] = @level - 1
      
      OPEN cur_GET_CHILD_SSCC
      FETCH NEXT FROM cur_GET_CHILD_SSCC 
      INTO @Corder_number,
           @Csscc 
      
      WHILE @@FETCH_STATUS = 0
      BEGIN
      	INSERT INTO @Shipping_Order_Details_Browse  
         SELECT @Corder_number,
                @Csscc,
                PAG.pag_sscc,
                MMR.mmr_gtin,
                MMR.mmr_item_no,
                ORD.ord_batch_no,
                PCK.pck_id,
                @level
         FROM Case_Aggregations CAG
         INNER JOIN Package_Aggregations PAG ON (PAG.pag_sscc = CAG.cag_sscc)      
         INNER JOIN Package_List PCK ON (PCK.pck_id = PAG.pag_pck_id)
         INNER JOIN Order_List ORD ON (ORD.ord_order_id = PCK.pck_order_id)
         INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id) 
         WHERE CAG.cag_parent_sscc = @Csscc
         
      	FETCH NEXT FROM cur_GET_CHILD_SSCC 
         INTO @Corder_number,
              @Csscc 
      END
      
      CLOSE cur_GET_CHILD_SSCC
      DEALLOCATE cur_GET_CHILD_SSCC
   
      GOTO BASLA
   END
           
            
   INSERT INTO @Shipping_Packages 
   SELECT order_number,
          gtin,
          item_no,
          batch_no,
          COUNT(package_id) AS quantity
   FROM @Shipping_Order_Details_Browse
   GROUP BY order_number,
            gtin,
            item_no,
            batch_no
            
   RETURN
END
GO

/****** Object: Function [dbo].[fn_get_shipping_packages_with_aggregations]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_get_shipping_packages_with_aggregations]') AND type IN ('FN', 'IF', 'IS', 'TF', 'FS', 'FT')))
BEGIN
	DROP FUNCTION [dbo].[fn_get_shipping_packages_with_aggregations]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_get_shipping_packages_with_aggregations](@order_number NVARCHAR(20))
RETURNS @Shipping_Order_Details_Browse TABLE
   (parent_sscc  VARCHAR(20),
    package_sscc VARCHAR(20),
    gtin         VARCHAR(14),
    batch_no     VARCHAR(20),
    expiry_date  VARCHAR(10),
    package_code VARCHAR(32),
    package_id   INT,
    [level]      TINYINT)
/*
{******************************************************************************}
{  Amaç         : Sevkiyat iş emrinin detaylarının listelenmesi.               }
{																										 }
{  Param. Gelen : order_number (İş emri numarası)                              }
{																										 }
{  Açıklama     :                                                              }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     09/12/2011  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
AS
BEGIN
   DECLARE @level TINYINT 
   DECLARE @Csscc VARCHAR(20)
   
   SET @level = 0
     
   INSERT INTO @Shipping_Order_Details_Browse
   SELECT CAST(NULL AS VARCHAR(20)) AS parent_sscc,
          SOD.sod_sscc,
          MMR.mmr_gtin,
          ORD.ord_batch_no,
          CONVERT(VARCHAR(10), ORD.ord_expiry_date, 120) AS expiry_date,
          PCK.pck_code,
          PCK.pck_id,
          0 AS [level]
   FROM Shipping_Order_List SOR
   INNER JOIN Shipping_Order_Details SOD ON (SOD.sod_sor_id = SOR.sor_id)
   INNER JOIN Package_Aggregations PAG ON (PAG.pag_sscc = SOD.sod_sscc)      
   INNER JOIN Package_List PCK ON (PCK.pck_id = PAG.pag_pck_id)
   INNER JOIN Order_List ORD ON (ORD.ord_order_id = PCK.pck_order_id)
   INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id) 
   WHERE SOR.sor_order_number = @order_number
   
   BASLA:
   
   IF EXISTS(SELECT 1
             FROM Case_Aggregations CAG
             INNER JOIN @Shipping_Order_Details_Browse TMP ON (TMP.package_sscc = cag_parent_sscc)
             WHERE [level] = @level)
   BEGIN                            
      SET @level = @level + 1

      DECLARE cur_GET_CHILD_SSCC CURSOR FOR 
      SELECT DISTINCT
             package_sscc
      FROM @Shipping_Order_Details_Browse       
      WHERE [level] = @level - 1
      
      OPEN cur_GET_CHILD_SSCC
      FETCH NEXT FROM cur_GET_CHILD_SSCC 
      INTO @Csscc 
      
      WHILE @@FETCH_STATUS = 0
      BEGIN
      	INSERT INTO @Shipping_Order_Details_Browse  
         SELECT @Csscc,
                PAG.pag_sscc,
                MMR.mmr_gtin,
                ORD.ord_batch_no,
                CONVERT(VARCHAR(10), ORD.ord_expiry_date, 120) AS expiry_date,
                PCK.pck_code,
                PCK.pck_id,
                @level
         FROM Case_Aggregations CAG
         INNER JOIN Package_Aggregations PAG ON (PAG.pag_sscc = CAG.cag_sscc)      
         INNER JOIN Package_List PCK ON (PCK.pck_id = PAG.pag_pck_id)
         INNER JOIN Order_List ORD ON (ORD.ord_order_id = PCK.pck_order_id)
         INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id) 
         WHERE CAG.cag_parent_sscc = @Csscc
         
      	FETCH NEXT FROM cur_GET_CHILD_SSCC 
         INTO @Csscc 
      END
      
      CLOSE cur_GET_CHILD_SSCC
      DEALLOCATE cur_GET_CHILD_SSCC
   
      GOTO BASLA
   END
  
   RETURN
END
GO

/****** Object: Function [dbo].[Fn_Sifre_Coz]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Fn_Sifre_Coz]') AND type IN ('FN', 'IF', 'IS', 'TF', 'FS', 'FT')))
BEGIN
	DROP FUNCTION [dbo].[Fn_Sifre_Coz]
END

GO

SET ANSI_NULLS OFF
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[Fn_Sifre_Coz](@Cozulecek VARCHAR(50))
RETURNS  VARCHAR(50)
AS
BEGIN
       DECLARE @cozulen VARCHAR(50)
       SET @cozulen=CAST(CAST(@cozulecek AS VARBINARY(102)) AS VARCHAR(50)) 
       RETURN(@cozulen)
END
GO

/****** Object: Function [dbo].[Fn_Sifre_Olustur]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Fn_Sifre_Olustur]') AND type IN ('FN', 'IF', 'IS', 'TF', 'FS', 'FT')))
BEGIN
	DROP FUNCTION [dbo].[Fn_Sifre_Olustur]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[Fn_Sifre_Olustur](@sifrelenecek VARCHAR(50))
RETURNS  VARBINARY(102)
AS
BEGIN
       DECLARE @sifre   VARBINARY(102)
      SET @sifre=CONVERT(VARBINARY(102),@sifrelenecek) 
      RETURN(@sifre)
END
GO

/****** Object: Stored Procedure [dbo].[All_Production_Declaration_Report]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[All_Production_Declaration_Report]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[All_Production_Declaration_Report]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[All_Production_Declaration_Report]
AS
/*
   SELECT COUNT(DISTINCT PMM.pmm_order_id) AS count_of_order_id,
          dbo.TRK(MMR.mmr_drug_group) AS mmr_drug_group
   FROM Package_Movement_Master PMM
   INNER JOIN Order_List ORD ON (ORD.ord_order_id = PMM.pmm_order_id)
   INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id)
   WHERE PMM.pmm_type = 'P'
     AND PMM.pmm_environment = 'G'
     AND PMM.pmm_declaration_id IS NOT NULL
   GROUP BY MMR.mmr_drug_group
   ORDER BY count_of_order_id DESC
*/            

   WITH MalzemeGruplari AS (
   SELECT CASE 
            WHEN SUM(count_of_order_id) < 70 THEN N'DİĞERLERİ'
            ELSE dbo.TRK(mmr_drug_group)
          END AS mmr_drug_group,
          SUM(count_of_order_id) AS count_of_order_id
   FROM (SELECT COUNT(DISTINCT PMM.pmm_order_id) AS count_of_order_id,
                MMR.mmr_drug_group
         FROM Package_Movement_Master PMM
         INNER JOIN Order_List ORD ON (ORD.ord_order_id = PMM.pmm_order_id)
         INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id)
         WHERE PMM.pmm_type = 'P'
           AND PMM.pmm_environment = 'G'
           AND PMM.pmm_declaration_id IS NOT NULL
         GROUP BY MMR.mmr_drug_group) T
   GROUP BY mmr_drug_group)    
   
   SELECT mmr_drug_group,
          SUM(count_of_order_id) AS count_of_order_id
   FROM MalzemeGruplari      
   GROUP BY mmr_drug_group
   ORDER BY CASE mmr_drug_group
               WHEN N'DİĞERLERİ' THEN 0
               ELSE SUM(count_of_order_id)
            END DESC
GO

/****** Object: Stored Procedure [dbo].[Cancelled_Sales_Browse]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cancelled_Sales_Browse]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Cancelled_Sales_Browse]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Cancelled_Sales_Browse]
AS 
/*
{*****************************************************************************}
{  Amaç         : Satış iptal bildirimlerinin listelenmesi.                   }
{  Param. Gelen :                              }
{                                                                             }
{  Açıklama     :                                                             }
{                                                                             }
{  Düzenleme Tarihçesi:                                                       }
{  Versiyon  Tarih       Kişi     Açıklama                                    }
{    1.1     22/02/2012  AY       Başlanıldı                                  }
{                                                                             }
{  Kısaltmalar:                                                               }
{  AY : Ali YAZICI                                                            }
{*****************************************************************************} 
*/
   SELECT CSM.csm_id,
          CSM.csm_document_number,
          CSM.csm_creation_date,
          AMR.amr_account_code,
          dbo.TRK(AMR.amr_account_name) AS amr_account_name,          
          AMR.amr_account_code + ' / ' + dbo.TRK(AMR.amr_account_name) AS account_name,
          COM.com_gln_number,
          AMR.amr_gln_number,
          (SELECT TOP 1 PMM.pmm_datetime
           FROM Package_Movement_Master PMM  WITH (NOLOCK)
           INNER JOIN Package_Movement_Detail PMD WITH (NOLOCK) ON (PMD.pmd_pmm_id = PMM.pmm_id)
           WHERE PMD.pmd_response_code = '00000'
             AND PMM.pmm_order_id = CSM.csm_document_number
             AND PMM.pmm_type = 'T'
           ORDER BY PMM.pmm_id DESC) AS declaration_datetime,
          ISNULL((SELECT COUNT(CSD.csd_id)
                  FROM Cancelled_Sales_Detail CSD
                  WHERE CSD.csd_csm_id = CSM.csm_id), 0) AS package_count
   FROM Cancelled_Sales_Master CSM
   INNER JOIN Account_Master AMR ON (AMR.amr_account_code = CSM.csm_account_code)
   INNER JOIN Companies COM ON (COM.com_id = CSM.csm_com_id)
GO

/****** Object: Stored Procedure [dbo].[Cancelled_Sales_Detail_Browse]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cancelled_Sales_Detail_Browse]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Cancelled_Sales_Detail_Browse]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Cancelled_Sales_Detail_Browse]
   @csd_csm_id          INT
AS 
/*
{*****************************************************************************}
{  Amaç         : Satış iptal bildirimi yapılacak ambalajların detay          }
{                 kayıtlarını listelemek.                                     }
{  Param. Gelen : csd_csm_id (Satış İptal Başlık Id)                          }
{                                                                             }
{  Açıklama     :                                                             }
{                                                                             }
{  Düzenleme Tarihçesi:                                                       }
{  Versiyon  Tarih       Kişi     Açıklama                                    }
{    1.1     22/02/2012  AY       Başlanıldı                                  }
{                                                                             }
{  Kısaltmalar:                                                               }
{  AY : Ali YAZICI                                                            }
{*****************************************************************************} 
*/
   SELECT CSD.csd_id,
          MMR.mmr_item_no,
          MMR.mmr_item_name,
          MMR.mmr_item_no + ' / ' + dbo.TRK(MMR.mmr_item_name) AS item_name,       
          MMR.mmr_gtin,
          ORD.ord_batch_no,
          ORD.ord_expiry_date,
          PCK.pck_code,
          PCK.pck_id
   FROM Cancelled_Sales_Detail CSD
   INNER JOIN Package_List PCK WITH (NOLOCK) ON (PCK.pck_id = CSD.csd_pck_id)
   INNER JOIN Order_List ORD WITH (NOLOCK) ON (ORD.ord_order_id = PCK.pck_order_id)
   INNER JOIN Material_Master MMR WITH (NOLOCK) ON (MMR.mmr_id = ORD.ord_mmr_id)
   WHERE CSD.csd_csm_id = @csd_csm_id
   ORDER BY CSD.csd_id
GO

/****** Object: Stored Procedure [dbo].[Cancelled_Sales_Detail_Delete]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cancelled_Sales_Detail_Delete]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Cancelled_Sales_Detail_Delete]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Cancelled_Sales_Detail_Delete]
   @csd_id          INT
AS 
/*
{*****************************************************************************}
{  Amaç         : Satış iptal bildirimi yapılacak ambalajların detay          }
{                 kaydını silmek.                                             }
{  Param. Gelen : csd_id (Satış İptal Detay Id)                               }
{                                                                             }
{  Açıklama     :                                                             }
{                                                                             }
{  Düzenleme Tarihçesi:                                                       }
{  Versiyon  Tarih       Kişi     Açıklama                                    }
{    1.0     22/02/2012  AY       Başlanıldı                                  }
{                                                                             }
{  Kısaltmalar:                                                               }
{  AY : Ali YAZICI                                                            }
{*****************************************************************************} 
*/
   IF EXISTS(SELECT 1
             FROM Package_List PCK WITH (NOLOCK)
             INNER JOIN Cancelled_Sales_Detail CSD WITH (NOLOCK) ON (CSD.csd_pck_id = PCK.pck_id)
             WHERE CSD.csd_id = @csd_id
               AND PCK.pck_status = 'T')
   BEGIN
      RAISERROR(N'Silmek istediğiniz ambalajın satış iptal bildirimi yapılmış. Bu ambalaj listeden silemezsiniz!', 16, 1)
      RETURN
   END


   BEGIN TRY   
      DELETE Cancelled_Sales_Detail
      WHERE csd_id = @csd_id
   END TRY          
   BEGIN CATCH
      DECLARE @ERROR_MESSAGE NVARCHAR(2048)
      SET @ERROR_MESSAGE = ERROR_MESSAGE()
      RAISERROR(N'Kayıt eklenemedi. Hata = %s', 16, 1, @ERROR_MESSAGE)    
   END CATCH
GO

/****** Object: Stored Procedure [dbo].[Cancelled_Sales_Detail_Insert]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cancelled_Sales_Detail_Insert]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Cancelled_Sales_Detail_Insert]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Cancelled_Sales_Detail_Insert]
   @account_code        VARCHAR(12),
   @csd_csm_id          INT,    
   @csd_pck_id          INT,
   @usr_id              INT
AS 
/*
{*****************************************************************************}
{  Amaç         : Satış iptal bildirimi yapılacak ambalajların detay          }
{                 kaydını eklemek.                                            }
{  Param. Gelen : account_code (Cari Hesap Kodu)                              }
{                 csd_csm_id (Satış İptal Başlık Id)                          }
{                 csd_pck_id (Ambalaj Id)                                     }
{               	usr_id (Kaydı Ekleyen Kullanıcı Id)                         }
{                                                                             }
{  Açıklama     :                                                             }
{                                                                             }
{  Düzenleme Tarihçesi:                                                       }
{  Versiyon  Tarih       Kişi     Açıklama                                    }
{    1.1     16/01/2012  AY       Başlanıldı                                  }
{                                                                             }
{  Kısaltmalar:                                                               }
{  AY : Ali YAZICI                                                            }
{*****************************************************************************} 
*/
   IF EXISTS(SELECT 1
             FROM Package_List
             WHERE pck_id = @csd_pck_id
               AND pck_status <> 'S')
   BEGIN
      RAISERROR(N'070108-DSI-0001 - Eklemek istediğiniz ambalajın satış bildirimi yapılmamış. Bu ambalaj için satış iptal bildirimi yapılamaz!', 16, 1)
      RETURN
   END

   IF EXISTS(SELECT 1
             FROM Cancelled_Sales_Detail
             WHERE csd_pck_id = @csd_pck_id
               AND csd_status = 'W')
   BEGIN
      RAISERROR(N'070108-DSI-0002 - Eklemek istediğiniz ambalaj daha önce satış iptal listesine eklenmiş. Bu ambalaj eklenemez!', 16, 1)
      RETURN   
   END

   IF EXISTS(SELECT 1
             FROM Package_List PCK
             WHERE PCK.pck_id = @csd_pck_id
               AND PCK.pck_last_sold_account_code <> @account_code) 
   BEGIN
      RAISERROR(N'070108-DSI-0003 - Eklemek istediğiniz ambalaj bildirim yapılacak cariye satılmamış. Bu ambalaj eklenemez!', 16, 1)
      RETURN
   END
   
   BEGIN TRY   
      IF @csd_csm_id IS NULL
      BEGIN
         DECLARE @csm_com_id          INT
                 
         SELECT @csm_com_id = COM.com_id
         FROM Package_List PCK WITH (NOLOCK)
         INNER JOIN Order_List ORD WITH (NOLOCK) ON (ORD.ord_order_id = PCK.pck_order_id)
         INNER JOIN Material_Master MMR WITH (NOLOCK) ON (MMR.mmr_id = ORD.ord_mmr_id)
         INNER JOIN Companies COM WITH (NOLOCK) ON (COM.com_registered_to_id = MMR.mmr_registered_to)
         WHERE PCK.pck_id = @csd_pck_id
                  
         EXEC @csd_csm_id = Cancelled_Sales_Master_Insert NULL, @account_code, @csm_com_id, @usr_id         
      END
      
      INSERT INTO Cancelled_Sales_Detail
             (csd_csm_id,
              csd_pck_id,
              csd_usr_id)
      VALUES (@csd_csm_id,
              @csd_pck_id,
              @usr_id)
   END TRY          
   BEGIN CATCH
      DECLARE @ERROR_MESSAGE NVARCHAR(2048)
      SET @ERROR_MESSAGE = ERROR_MESSAGE()
      RAISERROR(N'070108-DSI-0004 - Kayıt eklenemedi. Hata = %s', 16, 1, @ERROR_MESSAGE)    
      RETURN -1
   END CATCH
   
   RETURN @csd_csm_id
GO

/****** Object: Stored Procedure [dbo].[Cancelled_Sales_Insert_From_Shipping]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cancelled_Sales_Insert_From_Shipping]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Cancelled_Sales_Insert_From_Shipping]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Cancelled_Sales_Insert_From_Shipping]
   @sor_id  INT,
   @usr_id  INT
AS 
/*
{*****************************************************************************}
{  Amaç         : Bir sipariş kaydının tamamının satış iptal bildirimi        }
{                 yapılması için eklenmesi.                                   }
{  Param. Gelen : sor_id (Satış Başlık Id)                                    }
{               	usr_id (Kaydı Ekleyen Kullanıcı Id)                         }
{                                                                             }
{  Açıklama     :                                                             }
{                                                                             }
{  Düzenleme Tarihçesi:                                                       }
{  Versiyon  Tarih       Kişi     Açıklama                                    }
{    1.1     22/02/2012  AY       Başlanıldı                                  }
{                                                                             }
{  Kısaltmalar:                                                               }
{  AY : Ali YAZICI                                                            }
{*****************************************************************************} 
*/   
   DECLARE @csm_id            INT,
           @account_code      VARCHAR(12),
           @com_id            INT,
           @pck_id            INT,
           @sor_order_number  NVARCHAR(20)
               
   SELECT @account_code = SOR.sor_account_code,
          @com_id = SOR.sor_com_id,
          @sor_order_number = SOR.sor_order_number
   FROM Shipping_Order_List SOR
   WHERE SOR.sor_id = @sor_id

   IF NOT EXISTS(SELECT 1
                 FROM dbo.fn_get_shipping_packages_with_aggregations(@sor_order_number) AGG
                 INNER JOIN Package_List PCK WITH (NOLOCK) ON (PCK.pck_id = AGG.package_id)
                 WHERE PCK.pck_status = 'S')
   BEGIN
      RAISERROR(N'070104-DSI-0001 - Satış kaydının bildirimi yapılmamış. Satış iptal yapamazsınız!', 16, 1)
      RETURN
   END
      
   BEGIN TRY      
      EXEC @csm_id = Cancelled_Sales_Master_Insert NULL, @account_code, @com_id, @usr_id
            
      INSERT INTO Cancelled_Sales_Detail
             (csd_csm_id,
              csd_pck_id,
              csd_usr_id)
      SELECT  @csm_id,
              PCK.pck_id,
              @usr_id
      FROM dbo.fn_get_shipping_packages_with_aggregations(@sor_order_number) AGG
      INNER JOIN Package_List PCK WITH (NOLOCK) ON (PCK.pck_id = AGG.package_id)
      LEFT JOIN Cancelled_Sales_Detail CSD ON (CSD.csd_pck_id = PCK.pck_id AND CSD.csd_status = 'W')
      WHERE PCK.pck_status = 'S'
        AND CSD.csd_id IS NULL
   END TRY          
   BEGIN CATCH
      DECLARE @ERROR_MESSAGE NVARCHAR(2048)
      SET @ERROR_MESSAGE = ERROR_MESSAGE()
      RAISERROR(N'070104-DSI-0002 - Kayıt eklenemedi. Hata = %s', 16, 1, @ERROR_MESSAGE)    
      RETURN -1
   END CATCH
   
   RETURN @csm_id
GO

/****** Object: Stored Procedure [dbo].[Cancelled_Sales_Master_Browse]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cancelled_Sales_Master_Browse]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Cancelled_Sales_Master_Browse]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Cancelled_Sales_Master_Browse]
   @csm_id          INT
AS 
/*
{*****************************************************************************}
{  Amaç         : Satış iptal bildirimi başlık bilgilerinin listelenmesi.     }
{  Param. Gelen : csm_id (Satış İptal Başlık Id)                              }
{                                                                             }
{  Açıklama     :                                                             }
{                                                                             }
{  Düzenleme Tarihçesi:                                                       }
{  Versiyon  Tarih       Kişi     Açıklama                                    }
{    1.1     22/02/2012  AY       Başlanıldı                                  }
{                                                                             }
{  Kısaltmalar:                                                               }
{  AY : Ali YAZICI                                                            }
{*****************************************************************************} 
*/
   SELECT CSM.csm_id,
          CSM.csm_document_number,
          CSM.csm_creation_date,
          AMR.amr_account_code,
          dbo.TRK(AMR.amr_account_name) AS amr_account_name,          
          AMR.amr_account_code + ' / ' + dbo.TRK(AMR.amr_account_name) AS account_name,
          COM.com_gln_number,
          AMR.amr_gln_number
   FROM Cancelled_Sales_Master CSM
   INNER JOIN Account_Master AMR ON (AMR.amr_account_code = CSM.csm_account_code)
   INNER JOIN Companies COM ON (COM.com_id = CSM.csm_com_id)
   WHERE csm_id = @csm_id
GO

/****** Object: Stored Procedure [dbo].[Cancelled_Sales_Master_Delete]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cancelled_Sales_Master_Delete]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Cancelled_Sales_Master_Delete]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Cancelled_Sales_Master_Delete]
   @csm_id INT
AS 
/*
{*****************************************************************************}
{  Amaç         : Satış iptal bildirimi yapılmamış kaydı silmek.              }
{  Param. Gelen : csm_id (Satış İptal Başlık Id)                              }
{                                                                             }
{  Açıklama     :                                                             }
{                                                                             }
{  Düzenleme Tarihçesi:                                                       }
{  Versiyon  Tarih       Kişi     Açıklama                                    }
{    1.1     16/02/2012  AY       Başlanıldı                                  }
{                                                                             }
{  Kısaltmalar:                                                               }
{  AY : Ali YAZICI                                                            }
{*****************************************************************************} 
*/
   IF EXISTS(SELECT 1   
             FROM Cancelled_Sales_Detail
             WHERE csd_csm_id = @csm_id
               AND csd_status = 'F')
   BEGIN
      RAISERROR(N'Silmek istediğiniz kaydın içinde bildirim yapılmış detaylar mevcut. Kayıt silinemez!', 16, 1)
      RETURN
   END
   
   BEGIN TRY   
      DELETE Cancelled_Sales_Detail
      WHERE csd_csm_id = @csm_id
      
      DELETE Cancelled_Sales_Master
      WHERE csm_id = @csm_id
   END TRY          
   BEGIN CATCH
      DECLARE @ERROR_MESSAGE NVARCHAR(2048)
      SET @ERROR_MESSAGE = ERROR_MESSAGE()
      RAISERROR(N'Kayıt silinemedi. Hata = %s', 16, 1, @ERROR_MESSAGE)      
   END CATCH
GO

/****** Object: Stored Procedure [dbo].[Cancelled_Sales_Master_Insert]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cancelled_Sales_Master_Insert]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Cancelled_Sales_Master_Insert]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Cancelled_Sales_Master_Insert]
   @csm_document_number NVARCHAR(20), 
   @csm_account_code    VARCHAR(12),
   @csm_com_id          INT,
   @usr_id              INT
AS 
/*
{*****************************************************************************}
{  Amaç         : Satış iptal bildirimi yapılacak ambalajların başlık         }
{                 kaydını eklemek.                                            }
{  Param. Gelen : csm_document_number (Doküman Numarası)                      }
{                 csm_account_code (Cari Kodu)                                }
{                 csm_com_id (Şirket Id)                                      }
{               	usr_id (Kaydı Ekleyen Kullanıcı Id)                         }
{                                                                             }
{  Açıklama     :                                                             }
{                                                                             }
{  Düzenleme Tarihçesi:                                                       }
{  Versiyon  Tarih       Kişi     Açıklama                                    }
{    1.1     16/01/2012  AY       Başlanıldı                                  }
{                                                                             }
{  Kısaltmalar:                                                               }
{  AY : Ali YAZICI                                                            }
{*****************************************************************************} 
*/
   BEGIN TRY   
      INSERT INTO Cancelled_Sales_Master
             (csm_document_number,
              csm_account_code,
              csm_com_id,
              csm_usr_id)
      VALUES (@csm_document_number,
              @csm_account_code,
              @csm_com_id,
              @usr_id)
           
      DECLARE @csm_id INT
      SET @csm_id = SCOPE_IDENTITY()
         
      IF @csm_document_number IS NULL
      BEGIN
         SET @csm_document_number = 'T' + CAST(@csm_id AS NVARCHAR)
         
         UPDATE Cancelled_Sales_Master
         SET csm_document_number = @csm_document_number
         WHERE csm_id = @csm_id
      END              
   END TRY          
   BEGIN CATCH
      DECLARE @ERROR_MESSAGE NVARCHAR(2048)
      SET @ERROR_MESSAGE = ERROR_MESSAGE()
      RAISERROR(N'Kayıt eklenemedi. Hata = %s', 16, 1, @ERROR_MESSAGE)      
      RETURN -1
   END CATCH
   
   RETURN @csm_id
GO

/****** Object: Stored Procedure [dbo].[Daily_Declaration_Report]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Daily_Declaration_Report]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Daily_Declaration_Report]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Daily_Declaration_Report] --'A'
   @type CHAR(1) = 'U' -- U: Uretim emri bazında, A: Miktar bazında
AS
   IF @type = 'U'
   BEGIN
      WITH Tarihler AS (
      SELECT DATEADD(dd, M.number - 1, DATEDIFF(dd, 0, GETDATE()) - 7) AS GUN
      FROM master..spt_values AS M
      WHERE M.type = 'P'
        AND M.number BETWEEN 2 AND 8)       
                  
      SELECT CONVERT(VARCHAR(6), TRH.GUN, 106) AS GUN,
             COUNT(DISTINCT pmm_order_id) AS ADET
      FROM Tarihler TRH
      LEFT JOIN Package_Movement_Master PMM ON (DATEADD(dd, 0, DATEDIFF(dd, 0, PMM.pmm_datetime)) = TRH.GUN
                                            AND PMM.pmm_environment = 'G'
                                            AND PMM.pmm_declaration_id IS NOT NULL
                                            AND PMM.pmm_type = 'P')      
      GROUP BY TRH.GUN 
      ORDER BY TRH.GUN 
   END
   ELSE IF @type = 'A'
   BEGIN
      WITH Tarihler AS (
      SELECT DATEADD(dd, M.number - 1, DATEDIFF(dd, 0, GETDATE()) - 7) AS GUN
      FROM master..spt_values AS M
      WHERE M.type = 'P'
        AND M.number BETWEEN 2 AND 8)       
                  
      SELECT CONVERT(VARCHAR(6), TRH.GUN, 106) AS GUN,
             COUNT(DISTINCT pmd_pck_id) AS ADET
      FROM Tarihler TRH
      LEFT JOIN Package_Movement_Master PMM ON (DATEADD(dd, 0, DATEDIFF(dd, 0, PMM.pmm_datetime)) = TRH.GUN
                                            AND PMM.pmm_environment = 'G'
                                            AND PMM.pmm_declaration_id IS NOT NULL
                                            AND PMM.pmm_type = 'P')
      LEFT JOIN Package_Movement_Detail PMD ON (PMD.pmd_pmm_id = PMM.pmm_id)
      GROUP BY TRH.GUN 
      ORDER BY TRH.GUN 
   END
GO

/****** Object: Stored Procedure [dbo].[Declared_Detail_Report]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Declared_Detail_Report]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Declared_Detail_Report]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Declared_Detail_Report] 
   @ord_order_id  VARCHAR(20) = NULL,
   @mmr_item_name VARCHAR(50) = NULL,
   @begin_date    DATETIME = NULL,
   @end_date      DATETIME = NULL
AS
   SELECT @begin_date = CONVERT(DATETIME,(CONVERT(VARCHAR(10), @begin_date, 120)) + ' 00:00:01',120),
          @end_date = CONVERT(DATETIME,(CONVERT(VARCHAR(10), @end_date, 120)) + ' 23:59:59',120)
          
   SELECT *
   FROM (SELECT ORD.ord_order_id,
                MMR.mmr_item_no,
                dbo.TRK(MMR.mmr_item_name) AS mmr_item_name,
                ORD.ord_batch_no,
                ORD.ord_expiry_date,
                COUNT(PCK.pck_id) AS count_of_package,
                (SELECT MAX(PMM.pmm_datetime)
                 FROM Package_Movement_Master PMM
                 WHERE PMM.pmm_order_id = ORD.ord_order_id
                   AND PMM.pmm_type = 'P') AS datetime    
         FROM Package_List PCK
         INNER JOIN Order_List ORD ON (ORD.ord_order_id = PCK.pck_order_id)
         INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id)
         WHERE PCK.pck_status IN ('P', 'D')
           AND (ISNULL(@mmr_item_name, '') = '' OR MMR.mmr_item_name LIKE '\' + @mmr_item_name + '%' ESCAPE '\')
           AND (ISNULL(@ord_order_id, '') = '' OR ORD.ord_order_id LIKE '\' + @ord_order_id + '%' ESCAPE '\')       
         GROUP BY ORD.ord_order_id,
                  MMR.mmr_item_no,
                  MMR.mmr_item_name,
                  ORD.ord_batch_no,
                  ORD.ord_expiry_date) T
   WHERE T.datetime BETWEEN ISNULL(@begin_date, T.datetime) AND ISNULL(@end_date, T.datetime)                  
   ORDER BY T.datetime DESC
GO

/****** Object: Stored Procedure [dbo].[Error_Insert]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Error_Insert]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Error_Insert]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Error_Insert]
   @pmm_id            INT,
   @error_message     VARCHAR(100)
AS
   INSERT INTO Errors
          (err_pmm_id,
           err_error_message)
   VALUES (@pmm_id,
           @error_message)
           
   IF @@ROWCOUNT = 0 OR @@ERROR <> 0
   BEGIN
      RAISERROR('Hata kaydedilemedi!', 16, 1)
      RETURN -1
   END
GO

/****** Object: Stored Procedure [dbo].[Get_All_Data_From_TTS]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Get_All_Data_From_TTS]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Get_All_Data_From_TTS]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_All_Data_From_TTS]
   @order_ids VARCHAR(200),
   @pck_usr_id INT = NULL   
AS
   DECLARE @I INT
   DECLARE @S VARCHAR(20)

   SET NOCOUNT ON 
   
	CREATE TABLE #order_ids (order_id VARCHAR(20))
   SET @I = 0
   SET @S = ''

   WHILE LEN(@order_ids) > @I
   BEGIN
      SET @I = @I + 1
      IF (SUBSTRING(@order_ids, @I, 1) = ',')
      BEGIN
         INSERT INTO #order_ids
         SELECT @S
			SET @S=''
         CONTINUE
      END
      SET  @S = @S + SUBSTRING(@order_ids, @I, 1)
   END

   SET NOCOUNT OFF
   
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
          ord_code_order_id)
   SELECT CASE 
            WHEN CASE 
                  WHEN PATINDEX('%[_]%', TB022_ORDER_ID) > 0 THEN SUBSTRING(TB022_ORDER_ID, 1, PATINDEX('%[_]%', TB022_ORDER_ID) - 1)
                  ELSE TB022_ORDER_ID
                 END > '10000' THEN CASE 
                                       WHEN PATINDEX('%[_]%', TB022_ORDER_ID) > 0 THEN SUBSTRING(TB022_ORDER_ID, 1, PATINDEX('%[_]%', TB022_ORDER_ID) - 1)
                                       ELSE TB022_ORDER_ID
                                    END
            ELSE TB022_ORDER_ID
          END,	
          ISNULL(TB022_PK_BATCH_NO, TB022_ORDER_ID),
   	    TB022_SEQUENCE_ORDER,
   	    TB022_ORDER_TYPE,
   	    TB022_ORDER_STATUS_ID,
   	    TB022_LINE_ID,
   	    mmr_id,
   	    TB022_TARGET_QTY,
   	    TB022_UOM_TARGET_ID,
          ISNULL(TB022_REAL_START_DATE, GETDATE()),
   	    TB022_REAL_END_DATE,
   	    TB022_EXPIRY_DATE,
   	    TB022_CODE_ORDER_ID
   FROM TTS.TTS.dbo.TB022_TTORDERS 
   INNER JOIN TTS.TTS.dbo.TB020_ITEM_MASTER ON (TB020_ITEM_ID = TB022_ITEM_ID)
   INNER JOIN Material_Master ON (mmr_gtin = TB020_GTIN)
   WHERE TB022_ORDER_ID IN (SELECT order_id FROM #order_ids)
     AND CASE 
            WHEN PATINDEX('%[_]%', TB022_ORDER_ID) > 0 THEN SUBSTRING(TB022_ORDER_ID, 1, PATINDEX('%[_]%', TB022_ORDER_ID) - 1)
            ELSE TB022_ORDER_ID
         END NOT IN (SELECT ord_order_id FROM Order_List)
   ORDER BY TB022_CODE_ORDER_ID
   
   UPDATE Package_List
   SET pck_status_id = 10
   WHERE pck_original_order_id IN (SELECT order_id FROM #order_ids)
     AND pck_status_id <> 10
     
	INSERT INTO Package_List
         (pck_code,
          pck_order_id,
          pck_status_id,
          pck_device_id,
          pck_cell_id,
          pck_timestamp,
          pck_is_filled,
          pck_usr_id,
          pck_original_order_id,
          pck_was_printed,
          pck_source)
	SELECT TB027_USC,
          CASE 
            WHEN CASE 
                  WHEN PATINDEX('%[_]%', TB027_ORDER_ID) > 0 THEN SUBSTRING(TB027_ORDER_ID, 1, PATINDEX('%[_]%', TB027_ORDER_ID) - 1)
                  ELSE TB027_ORDER_ID
                 END > '10000' THEN CASE 
                                       WHEN PATINDEX('%[_]%', TB027_ORDER_ID) > 0 THEN SUBSTRING(TB027_ORDER_ID, 1, PATINDEX('%[_]%', TB027_ORDER_ID) - 1)
                                       ELSE TB027_ORDER_ID
                                    END
            ELSE TB027_ORDER_ID
          END,	
	       10,
	       NULL,
	       TB027_CELL_ID,
	       GETDATE(),
	       -1,
	       @pck_usr_id,
	       TB027_ORDER_ID,
	       0,
	       'TTS'
	FROM TTS.TTS.dbo.TB027_USC_LIST
	WHERE TB027_ORDER_ID IN (SELECT order_id FROM #order_ids)
     AND TB027_USC NOT IN (SELECT pck_code FROM Package_List)	
     
   DROP TABLE #order_ids
GO

/****** Object: Stored Procedure [dbo].[Get_All_Package_Code_From_TTS]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Get_All_Package_Code_From_TTS]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Get_All_Package_Code_From_TTS]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_All_Package_Code_From_TTS]
   @order_id VARCHAR(20) = NULL
/*
{******************************************************************************}
{  Amaç         : TTS veritabanından basılmayan ambalaj kodlarının alınması    }
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
AS
   DECLARE @USC_DATA TABLE (CODE	            VARCHAR(32),
                            INNER_CODE	      VARCHAR(32),
                            CODE_GTIN	      VARCHAR(20),
                            CODE_STATUS_ID	INT,
                            TIMESTAMP	      DATETIME)
     
   DECLARE @Corder_id VARCHAR(20),
           @Cphase    TINYINT
   
   IF @order_id IS NOT NULL
   BEGIN
      DECLARE @PRODUCTION_ORDER_LIST TABLE (ORDER_ID	         VARCHAR(20),
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

      INSERT INTO @PRODUCTION_ORDER_LIST
      EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Production_Order_Data_From_TTS @order_id, NULL, NULL
      
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
      SELECT ORDER_ID,
             BATCH_NO,
             NULL,
             'P',
             ORDER_STATUS_ID,
             LINE_ID,
             MMR.mmr_id,
             TARGET_QTY,
             NULL,
             CREATION_TIMESTAMP,
             CLOSED_TIMESTAMP,
             EXPIRY_TIMESTAMP,
             NULL,
             2
      FROM @PRODUCTION_ORDER_LIST ORD
      INNER JOIN Material_Master MMR ON (MMR.mmr_item_no = ORD.INTERNAL_CODE)
      LEFT JOIN Order_List ON (ord_order_id = ORD.ORDER_ID)
      WHERE ord_order_id IS NULL    
      
      UPDATE Order_List
      SET ord_order_status_id = ORDER_STATUS_ID
      FROM @PRODUCTION_ORDER_LIST
      WHERE ord_order_id = ORDER_ID
        AND ord_order_status_id <> ORDER_STATUS_ID  
        AND ord_phase = 2     
   END
   
   DECLARE cur_Get_All_Package_Code_From_TTS CURSOR FOR 
   SELECT ORD.ord_order_id,
          ORD.ord_phase
   FROM Order_List ORD
   WHERE ORD.ord_order_id NOT IN (SELECT DISTINCT pcp_order_id FROM Package_List_Not_Printed)
     AND ORD.ord_order_status_id IN (90, 100, 130, 140, 150)
     AND @order_id IS NULL
   UNION
   SELECT ORD.ord_order_id,
          ORD.ord_phase
   FROM Order_List ORD
   WHERE ORD.ord_order_id = @order_id
     AND @order_id IS NOT NULL
   
   OPEN cur_Get_All_Package_Code_From_TTS
   FETCH NEXT FROM cur_Get_All_Package_Code_From_TTS 
   INTO @Corder_id,
        @Cphase
   
   WHILE @@FETCH_STATUS = 0
   BEGIN
   	IF @Cphase = 1
      BEGIN
         INSERT INTO Package_List_Not_Printed
               (pcp_order_id,
                pcp_code)
         SELECT TB027_ORDER_ID,
                TB027_USC
      	FROM TTS.TTS.dbo.TB027_USC_LIST 
         LEFT JOIN Package_List WITH (NOLOCK) ON (pck_code = TB027_USC AND pck_original_order_id = @Corder_id)
      	WHERE TB027_ORDER_ID  = @Corder_id  
           AND pck_id IS NULL         
      END
      ELSE IF @Cphase = 2
      BEGIN
      	INSERT INTO @USC_DATA
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_USC_Data_From_TTS @Corder_id, NULL, 0, NULL    
         
         INSERT INTO Package_List_Not_Printed
               (pcp_order_id,
                pcp_code)
         SELECT @Corder_id,
                CODE
         FROM @USC_DATA    
         LEFT JOIN Package_List WITH (NOLOCK) ON (pck_code = CODE AND pck_original_order_id = @Corder_id)
         LEFT JOIN Package_List_Not_Printed WITH (NOLOCK) ON (pcp_code = CODE AND pcp_order_id = @Corder_id)
         WHERE pck_id IS NULL
           AND pcp_id IS NULL
           AND LEN(CODE_GTIN) = 14
         
         DELETE FROM @USC_DATA
      END
      
   	FETCH NEXT FROM cur_Get_All_Package_Code_From_TTS 
      INTO @Corder_id,
           @Cphase
   END
   
   CLOSE cur_Get_All_Package_Code_From_TTS
   DEALLOCATE cur_Get_All_Package_Code_From_TTS
GO

/****** Object: Stored Procedure [dbo].[Get_Data_From_WMS]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Get_Data_From_WMS]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Get_Data_From_WMS]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_Data_From_WMS]
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
   FROM TESTTCP.GENERAL.dbo.MMR_Manufacturer MMM
   INNER JOIN TESTTCP.GENERAL.dbo.Material_Master MMR ON (MMR.mmr_id = MMM.mmm_mmr_id)
   INNER JOIN TESTTCP.GENERAL.dbo.Drug_Group DRG ON (DRG.drg_drug_group_code = MMR.mmr_drug_group_code)
   LEFT JOIN Material_Master MMRI ON (MMRI.mmr_id = MMR.mmr_id)
   WHERE MMM.mmm_barcode <> ''   
     AND MMRI.mmr_id IS NULL

   INSERT INTO Account_Master
   SELECT AMR.amr_id,
          AMR.amr_account_code,
          AMR.amr_account_name,
          AMR.amr_gln_number,
          ADA.ada_gln_number
   FROM TESTTCP.GENERAL.dbo.Account_Master_Record AMR
   INNER JOIN TESTTCP.GENERAL.dbo.Account_Delivery_Address ADA ON (ADA.ada_amr_id = AMR.amr_id)
   LEFT JOIN Account_Master AMRI ON (AMRI.amr_id = AMR.amr_id)
   WHERE AMR.amr_gln_number IS NOT NULL
     AND ADA.ada_gln_number IS NOT NULL
     AND AMRI.amr_id IS NULL
     
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
          ord_code_order_id)
	SELECT CASE 
            WHEN PATINDEX('%[_]%', TB022_ORDER_ID) > 0 THEN SUBSTRING(TB022_ORDER_ID, 1, PATINDEX('%[_]%', TB022_ORDER_ID) - 1)
            ELSE TB022_ORDER_ID
          END,
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
      	 MAX(TB022_CODE_ORDER_ID)
   FROM TTS.TTS.dbo.TB022_TTORDERS 
   INNER JOIN TTS.TTS.dbo.TB020_ITEM_MASTER ON (TB020_ITEM_ID = TB022_ITEM_ID)
   INNER JOIN Material_Master ON (mmr_gtin = TB020_GTIN)
   WHERE TB022_ORDER_STATUS_ID = 90
     AND CASE 
            WHEN PATINDEX('%[_]%', TB022_ORDER_ID) > 0 THEN SUBSTRING(TB022_ORDER_ID, 1, PATINDEX('%[_]%', TB022_ORDER_ID) - 1)
            ELSE TB022_ORDER_ID
         END NOT IN (SELECT ord_order_id FROM Order_List)
     AND (CASE 
            WHEN PATINDEX('%[_]%', TB022_ORDER_ID) > 0 THEN SUBSTRING(TB022_ORDER_ID, 1, PATINDEX('%[_]%', TB022_ORDER_ID) - 1)
            ELSE TB022_ORDER_ID
          END > '10000' 
       OR CASE 
            WHEN PATINDEX('%[_]%', TB022_ORDER_ID) > 0 THEN SUBSTRING(TB022_ORDER_ID, 1, PATINDEX('%[_]%', TB022_ORDER_ID) - 1)
            ELSE TB022_ORDER_ID
          END BETWEEN 1000 AND 9999)    
     AND TB022_ORDER_ID <> '28275'         
	GROUP BY CASE 
               WHEN PATINDEX('%[_]%', TB022_ORDER_ID) > 0 THEN SUBSTRING(TB022_ORDER_ID, 1, PATINDEX('%[_]%', TB022_ORDER_ID) - 1)
               ELSE TB022_ORDER_ID
            END,
            ISNULL(TB022_PK_BATCH_NO, TB022_ORDER_ID),
      	   TB022_ORDER_TYPE,
      	   TB022_ORDER_STATUS_ID,
      	   TB022_LINE_ID,
      	   mmr_id,     
            TB022_UOM_TARGET_ID
   ORDER BY CASE 
               WHEN PATINDEX('%[_]%', TB022_ORDER_ID) > 0 THEN SUBSTRING(TB022_ORDER_ID, 1, PATINDEX('%[_]%', TB022_ORDER_ID) - 1)
               ELSE TB022_ORDER_ID
            END

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
   LEFT JOIN Package_List WITH (NOLOCK) ON (pck_code = TB028_CODE)
	WHERE TB022_ORDER_STATUS_ID = 90
     --AND TB028_CODE NOT IN (SELECT pck_code FROM Package_List)
     AND TB028_ORDER_ID <> '27478'
     AND pck_id IS NULL
     
     
     
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

/****** Object: Stored Procedure [dbo].[Get_Expiry_Date]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Get_Expiry_Date]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Get_Expiry_Date]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_Expiry_Date]
   @pom_id          INT,
   @expiry_date_    DATETIME OUTPUT
AS   
   DECLARE @expiry_date DATETIME
   
   DECLARE @sqlStatement NVARCHAR(600),
           @parmDefinition NVARCHAR(600)

   SET @sqlStatement = N'SELECT @expiry_date_out = [GENERAL].[dbo].[fn_get_expiry_date](@input)'
   SET @parmDefinition = N'@input INT, @expiry_date_out DATETIME output'

   EXEC [TESTTCP].[GENERAL].[dbo].sp_executesql
	   @statement = @sqlStatement,
      @params = @parmDefinition,
      @input = @pom_id,
	   @expiry_date_out = @expiry_date output
      
   SET @expiry_date_ = @expiry_date
GO

/****** Object: Stored Procedure [dbo].[Get_Production_Data_From_TTSV2]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Get_Production_Data_From_TTSV2]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Get_Production_Data_From_TTSV2]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_Production_Data_From_TTSV2] --'32334'
   @order_id VARCHAR(20) = NULL
WITH RECOMPILE
/*
{******************************************************************************}
{  Amaç         : TTS V2 veritabanından üretim verilerinin aktarılması.        }
{																										 }
{  Param. Gelen :                                                          	 }
{																										 }
{  Açıklama     :                       													 }
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
   --BEGIN TRANSACTION
   
   BEGIN TRY
      DECLARE @trl_id                  INT,
              @last_trl_finishing_time DATETIME
      
      IF @order_id IS NULL
      BEGIN
         SELECT TOP 1 @last_trl_finishing_time = trl_finishing_time 
         FROM Transfer_Logs
         WHERE trl_finishing_time IS NOT NULL
           AND trl_type = 0
         ORDER BY trl_finishing_time DESC
         
         INSERT INTO Transfer_Logs (trl_type) VALUES (0)
         SET @trl_id = SCOPE_IDENTITY()
         
         SET @last_trl_finishing_time = DATEADD(hh, -6, @last_trl_finishing_time)
      END
      
      DECLARE @USC_DATA_T TABLE (CODE	            VARCHAR(32),
                                 OUTER_USC	      VARCHAR(32),
                                 CODE_GTIN	      VARCHAR(20),
                                 CODE_STATUS_ID	   INT,
                                 TIMESTAMP	      DATETIME)

      DECLARE @USC_DATA TABLE (ORDER_ID         VARCHAR(20),
                               CODE	            VARCHAR(32),
                               OUTER_USC	      VARCHAR(32),
                               CODE_GTIN	      VARCHAR(20),
                               CODE_STATUS_ID	INT,
                               TIMESTAMP	      DATETIME)
      
      DECLARE @PRODUCTION_ORDER_LIST TABLE (ORDER_ID	         VARCHAR(20),
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
   
      IF @order_id IS NULL
      BEGIN
         INSERT INTO @PRODUCTION_ORDER_LIST
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Production_Order_Data_From_TTS NULL, 50, @last_trl_finishing_time
         INSERT INTO @PRODUCTION_ORDER_LIST
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Production_Order_Data_From_TTS NULL, 60, @last_trl_finishing_time
         INSERT INTO @PRODUCTION_ORDER_LIST
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Production_Order_Data_From_TTS NULL, 70, @last_trl_finishing_time
         INSERT INTO @PRODUCTION_ORDER_LIST
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Production_Order_Data_From_TTS NULL, 80, @last_trl_finishing_time
         INSERT INTO @PRODUCTION_ORDER_LIST
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Production_Order_Data_From_TTS NULL, 100, @last_trl_finishing_time
         INSERT INTO @PRODUCTION_ORDER_LIST
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Production_Order_Data_From_TTS NULL, 140, @last_trl_finishing_time
      END
      ELSE
      BEGIN
         INSERT INTO @PRODUCTION_ORDER_LIST
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Production_Order_Data_From_TTS @order_id, NULL, NULL

         DECLARE @C INT,
                 @O VARCHAR(50)
                 
         SET @C = 2
         WHILE 1 = 1
         BEGIN
            SET @O = @order_id + '_' + CAST(@C AS VARCHAR)
            INSERT INTO @PRODUCTION_ORDER_LIST
            EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Production_Order_Data_From_TTS @O, NULL, NULL         
            
            IF @@ROWCOUNT = 0 BREAK
            
            SET @C = @C + 1
         END
         
      END
      
      DECLARE @CORDER_ID VARCHAR(20),
              @CGTIN     VARCHAR(14)
      
      DECLARE cur_Get_Data_From_TTSV2 CURSOR FOR 
      SELECT DISTINCT
             ORD.ORDER_ID,
             MMR.mmr_gtin
      FROM @PRODUCTION_ORDER_LIST ORD
      INNER JOIN Material_Master MMR ON (MMR.mmr_item_no = ORD.INTERNAL_CODE)
      LEFT JOIN Package_List PCK WITH (NOLOCK) ON (PCK.pck_original_order_id = ORDER_ID)
      WHERE ORDER_ID NOT LIKE 'TEST%'
        AND ORDER_ID NOT IN ('16826', '16893', '16936', '16951', '16976', '16976_2', '16976_3', '16976_4')
        AND PCK.pck_id IS NULL
        AND @order_id IS NULL
      UNION
      SELECT DISTINCT 
             ORD.ord_order_id,
             MMR.mmr_gtin
      FROM Order_List ORD
      INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id)
      LEFT JOIN Package_List PCK WITH (NOLOCK) ON (PCK.pck_original_order_id = ORD.ord_order_id)
      WHERE ORD.ord_phase = 2
        AND PCK.pck_id IS NULL
        AND @order_id IS NULL
      UNION
      SELECT ORD.ORDER_ID,
             MMR.mmr_gtin
      FROM @PRODUCTION_ORDER_LIST ORD
      INNER JOIN Material_Master MMR ON (MMR.mmr_item_no = ORD.INTERNAL_CODE)
      WHERE @order_id IS NOT NULL
      
      OPEN cur_Get_Data_From_TTSV2
      FETCH NEXT FROM cur_Get_Data_From_TTSV2 
      INTO @CORDER_ID,
           @CGTIN
      
      WHILE @@FETCH_STATUS = 0
      BEGIN
      	INSERT INTO @USC_DATA_T
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_USC_Data_From_TTS_v3 @CORDER_ID, NULL, @CGTIN, 1, NULL
         
         INSERT INTO @USC_DATA
         SELECT @CORDER_ID,
                *
         FROM @USC_DATA_T
         
         DELETE FROM @USC_DATA_T  
         
         PRINT @CORDER_ID
         
      	FETCH NEXT FROM cur_Get_Data_From_TTSV2 
         INTO @CORDER_ID,
              @CGTIN
      END
      
      CLOSE cur_Get_Data_From_TTSV2
      DEALLOCATE cur_Get_Data_From_TTSV2
      
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
      SELECT ORDER_ID,
             BATCH_NO,
             NULL,
             'P',
             ORDER_STATUS_ID,
             LINE_ID,
             MMR.mmr_id,
             TARGET_QTY,
             NULL,
             CREATION_TIMESTAMP,
             CLOSED_TIMESTAMP,
             EXPIRY_TIMESTAMP,
             NULL,
             2
      FROM @PRODUCTION_ORDER_LIST ORD
      INNER JOIN Material_Master MMR ON (MMR.mmr_item_no = ORD.INTERNAL_CODE)
      LEFT JOIN Order_List ON (ord_order_id = ORD.ORDER_ID)
      WHERE ord_order_id IS NULL    
        AND ORDER_ID NOT LIKE 'TEST%'
        
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
             pck_source,
             pck_sscc,
             pck_previous_status_id)             
      SELECT CODE,
             CASE 
               WHEN PATINDEX('%[_]%', ORDER_ID) > 0 THEN SUBSTRING(ORDER_ID, 1, PATINDEX('%[_]%', ORDER_ID) - 1)
               ELSE ORDER_ID
             END,
             CASE CODE_STATUS_ID
               WHEN 65 THEN 10
               ELSE CODE_STATUS_ID
             END,
             NULL,
             NULL,
             TIMESTAMP,
             0,
             ORDER_ID,
             1,
             'TTS',
             CASE 
               WHEN OUTER_USC IS NULL THEN NULL
               ELSE CASE LEN(OUTER_USC)
                     WHEN 20 THEN OUTER_USC
                     ELSE '00' + OUTER_USC
                    END
             END,
             CASE CODE_STATUS_ID
               WHEN 65 THEN 65
               ELSE NULL
             END
      FROM @USC_DATA
      LEFT JOIN Package_List WITH (NOLOCK) ON (pck_code = CODE)
      WHERE pck_id IS NULL
        
      /*
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
             pck_source,
             pck_sscc,
             pck_previous_status_id)             
      SELECT INNER_CODE,
             CASE 
               WHEN PATINDEX('%[_]%', ORDER_ID) > 0 THEN SUBSTRING(ORDER_ID, 1, PATINDEX('%[_]%', ORDER_ID) - 1)
               ELSE ORDER_ID
             END,
             CASE CODE_STATUS_ID
               WHEN 65 THEN 10
               ELSE CODE_STATUS_ID
             END,
             NULL,
             NULL,
             TIMESTAMP,
             0,
             ORDER_ID,
             1,
             'TTS',
             CASE LEN(CODE)
               WHEN 20 THEN CODE
               ELSE '00' + CODE
             END,
             CASE CODE_STATUS_ID
               WHEN 65 THEN 65
               ELSE NULL
             END
      FROM @USC_DATA
      LEFT JOIN Package_List WITH (NOLOCK) ON (pck_code = INNER_CODE)
      WHERE INNER_CODE IS NOT NULL
        AND pck_id IS NULL
      
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
             pck_source,
             pck_previous_status_id)             
      SELECT CODE,
             CASE 
               WHEN PATINDEX('%[_]%', ORDER_ID) > 0 THEN SUBSTRING(ORDER_ID, 1, PATINDEX('%[_]%', ORDER_ID) - 1)
               ELSE ORDER_ID
             END,
             CASE CODE_STATUS_ID
               WHEN 65 THEN 10
               ELSE CODE_STATUS_ID
             END,
             NULL,
             NULL,
             TIMESTAMP,
             0,
             ORDER_ID,
             1,
             'TTS',
             CASE CODE_STATUS_ID
               WHEN 65 THEN 65
               ELSE NULL
             END
      FROM @USC_DATA
      LEFT JOIN Package_List WITH (NOLOCK) ON (pck_code = CODE)      
      WHERE INNER_CODE IS NULL
        AND CODE NOT IN (SELECT INNER_CODE FROM @USC_DATA WHERE INNER_CODE IS NOT NULL)        
        AND LEN(CODE_GTIN) = 14
        AND pck_id IS NULL
      */
      IF @order_id IS NULL
      BEGIN
         DELETE FROM @PRODUCTION_ORDER_LIST
         
         INSERT INTO @PRODUCTION_ORDER_LIST
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Production_Order_Data_From_TTS NULL, 50, NULL
         INSERT INTO @PRODUCTION_ORDER_LIST
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Production_Order_Data_From_TTS NULL, 60, NULL
         INSERT INTO @PRODUCTION_ORDER_LIST
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Production_Order_Data_From_TTS NULL, 70, NULL
         INSERT INTO @PRODUCTION_ORDER_LIST
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Production_Order_Data_From_TTS NULL, 80, NULL
         INSERT INTO @PRODUCTION_ORDER_LIST
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Production_Order_Data_From_TTS NULL, 100, NULL
         INSERT INTO @PRODUCTION_ORDER_LIST
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Production_Order_Data_From_TTS NULL, 140, NULL
        
         UPDATE Order_List
         SET ord_order_status_id = ORDER_STATUS_ID
         FROM @PRODUCTION_ORDER_LIST
         WHERE ord_order_id = ORDER_ID
           AND ord_order_status_id <> ORDER_STATUS_ID  
           AND ord_phase = 2      
         
         UPDATE Transfer_Logs
         SET trl_finishing_time = GETDATE()
         WHERE trl_id = @trl_id     
      END
      ELSE
      BEGIN
         UPDATE Package_List
         SET pck_sscc = CASE LEN(OUTER_USC)
                           WHEN 20 THEN OUTER_USC
                           ELSE '00' + OUTER_USC
                        END
         FROM @USC_DATA
         WHERE pck_code = CODE
           AND OUTER_USC IS NOT NULL
           AND pck_sscc IS NULL
        
         UPDATE Order_List
         SET ord_order_status_id = ORDER_STATUS_ID
         FROM @PRODUCTION_ORDER_LIST
         WHERE ord_order_id = ORDER_ID
           AND ord_order_status_id <> ORDER_STATUS_ID  
           AND ord_phase = 2            
      END
      
   END TRY
   BEGIN CATCH
      --ROLLBACK TRANSACTION
      RETURN
   END CATCH
   
   --COMMIT TRANSACTION
GO

/****** Object: Stored Procedure [dbo].[Get_Shipping_Data_From_TTSV2]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Get_Shipping_Data_From_TTSV2]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Get_Shipping_Data_From_TTSV2]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_Shipping_Data_From_TTSV2] 
   @order_number NVARCHAR(20) = NULL
/*
{******************************************************************************}
{  Amaç         : TTS V2 veritabanından satış verilerinin aktarılması.         }
{																										 }
{  Param. Gelen : order_number (Satış Numarası)                                }
{																										 }
{  Açıklama     :                       													 }
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
   DECLARE @SHIPPING_AGGR TABLE (SHIPPING_ORDER	VARCHAR(20),
                                 SSCC	         VARCHAR(32),
                                 PACKAGE_CODE	VARCHAR(32))
                                 
   DECLARE @SHIPPING_ORDER_LIST TABLE (ORDER_ID 	      VARCHAR(20),
                                       CUSTOMER_ID	      INT,
                                       GLN_PREFIX        CHAR(7),
                                       CARRIER	         VARCHAR(30),
                                       CARRIER_TRUCK	   VARCHAR(20),
                                       NOTE1	            VARCHAR(80),
                                       NOTE2	            VARCHAR(80),
                                       NOTE3	            VARCHAR(80),
                                       STATUS_ID	      CHAR(1),
                                       CREATION_DATE	   DATETIME,
                                       CLOSED_TIMESTAMP	DATETIME)

   DECLARE @ORDER_ID VARCHAR(20)
         
   BEGIN TRANSACTION
   
   BEGIN TRY      
      IF @order_number IS NULL
      BEGIN
         -- Verisi tekrar alınması gerekiyorsa alınan veri siliniyor
         DELETE Package_Aggregations
         WHERE pag_sscc IN (SELECT sod_sscc
                            FROM Shipping_Order_Details SOD
                            INNER JOIN Shipping_Order_List SOR ON (SOR.sor_id = SOD.sod_sor_id)
                            WHERE SOR.sor_transfer_again = 1)
                            
         DELETE Shipping_Order_Details
         FROM Shipping_Order_List
         WHERE sod_sor_id = sor_id
           AND sor_transfer_again = 1    
           
         DELETE Scheduled_Declaration
         FROM Shipping_Order_List SOR
         WHERE sch_order_id = SOR.sor_order_number
           AND sch_type IN ('S', 'C')
           AND sch_status = 'W'
           AND SOR.sor_transfer_again = 1                             
                       
         -- Verisi tekrar alınması gerekiyorsa alınacak
         DECLARE cur_Get_Transfer_Again_Orders CURSOR FOR 
         SELECT sor_order_number
         FROM Shipping_Order_List
         WHERE sor_transfer_again = 1
         
         OPEN cur_Get_Transfer_Again_Orders
         FETCH NEXT FROM cur_Get_Transfer_Again_Orders 
         INTO @ORDER_ID 
         
         WHILE @@FETCH_STATUS = 0
         BEGIN
         	INSERT INTO @SHIPPING_ORDER_LIST                                     
            EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Shipping_Order_Data_From_TTS @ORDER_ID, 'P', NULL
            
         	FETCH NEXT FROM cur_Get_Transfer_Again_Orders 
            INTO @ORDER_ID 
         END
         
         CLOSE cur_Get_Transfer_Again_Orders
         DEALLOCATE cur_Get_Transfer_Again_Orders

         UPDATE Shipping_Order_List
         SET sor_transfer_again = 0,
             sor_status = 'M'
         WHERE sor_transfer_again = 1
           AND sor_order_number IN (SELECT ORDER_ID FROM @SHIPPING_ORDER_LIST)

         DECLARE cur_Get_Shipping_Data_From_TTSV2 CURSOR FOR 
         SELECT ORDER_ID 
         FROM @SHIPPING_ORDER_LIST
         
         OPEN cur_Get_Shipping_Data_From_TTSV2
         FETCH NEXT FROM cur_Get_Shipping_Data_From_TTSV2 
         INTO @ORDER_ID 
         
         WHILE @@FETCH_STATUS = 0
         BEGIN
            INSERT INTO @SHIPPING_AGGR                                                                       
            EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Aggregations_From_TTS @ORDER_ID
            
         	FETCH NEXT FROM cur_Get_Shipping_Data_From_TTSV2 
            INTO @ORDER_ID 
         END
         
         CLOSE cur_Get_Shipping_Data_From_TTSV2
         DEALLOCATE cur_Get_Shipping_Data_From_TTSV2
                         
         DELETE FROM @SHIPPING_ORDER_LIST     
         ----------------------------------------------------------------------------------
         
         DECLARE @trl_id                  INT,
                 @last_trl_starting_time  DATETIME
                 
         SELECT TOP 1 @last_trl_starting_time = trl_starting_time 
         FROM Transfer_Logs
         WHERE trl_finishing_time IS NOT NULL
           AND trl_type = 1
         ORDER BY trl_finishing_time DESC
         
         INSERT INTO Transfer_Logs (trl_type) VALUES (1)
         SET @trl_id = SCOPE_IDENTITY()                  
         
         -- Öncelikle tipi O (Open) ve M (Managed) olanlar alınmalı
         INSERT INTO @SHIPPING_ORDER_LIST                                     
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Shipping_Order_Data_From_TTS NULL, 'O', NULL      
         INSERT INTO @SHIPPING_ORDER_LIST                                           
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Shipping_Order_Data_From_TTS NULL, 'M', NULL      
         /*
         INSERT INTO @SHIPPING_ORDER_LIST                                           
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Shipping_Order_Data_From_TTS '1772', NULL, NULL      
         */
              
         IF EXISTS(SELECT 1 FROM @SHIPPING_ORDER_LIST)
         BEGIN      
            INSERT INTO Shipping_Order_List
                  (sor_order_number,
                   sor_com_id,
                   sor_account_code,
                   sor_status,
                   sor_invoice_number,
                   sor_invoice_date,
                   sor_creation_date,
                   sor_completion_date)                      
            SELECT SHP.ORDER_ID,
                   CASE MOM.mom_db_code 
                     WHEN 4 THEN 1 
                     WHEN 6 THEN 2
                   END,
                   --COM.com_id,       
                   ISNULL(AMR.amr_account_code, CUS.TB073_CODE),
                   --CUS.TB073_CODE,
                   SHP.STATUS_ID,
                   MOM.mom_document_number,
                   MOM.mom_document_date,
                   SHP.CREATION_DATE,
                   GETDATE()
            FROM @SHIPPING_ORDER_LIST SHP
            INNER JOIN TTS2.TTS_Plant.dbo.TB073_WH_CUSTOMERS CUS ON (CUS.TB073_CUSTOMER_ID = SHP.CUSTOMER_ID)
   --         INNER JOIN Companies COM ON (LEFT(COM.com_gln_number, 7) = SHP.GLN_PREFIX)
            LEFT JOIN TESTTCP.GENERAL.dbo.Movement_Master MOM ON (CAST(MOM.mom_parameter_2 AS VARCHAR(20)) = SHP.ORDER_ID)
            /*
            LEFT JOIN Companies COM ON (COM.com_id = CASE MOM.mom_db_code 
                                                      WHEN 4 THEN 1 
                                                      WHEN 6 THEN 2
                                                     END)
            */
            LEFT JOIN Account_Master AMR ON (AMR.amr_id = MOM.mom_account_id)
            WHERE SHP.ORDER_ID NOT IN (SELECT sor_order_number FROM Shipping_Order_List)  
              AND MOM.mom_movement_type = 12
              AND MOM.mom_movement_direction = 2
         END
         
         UPDATE Transfer_Logs
         SET trl_finishing_time = GETDATE()
         WHERE trl_id = @trl_id
         
         DELETE FROM @SHIPPING_ORDER_LIST 
         
         DECLARE cur_Get_Completed_Shipping CURSOR FOR 
         SELECT sor_order_number
         FROM Shipping_Order_List SOR
         LEFT JOIN Shipping_Order_Details SOD ON (SOD.sod_sor_id = SOR.sor_id)
         WHERE sor_status IN ('O', 'M')
            OR (sor_status = 'P' AND SOD.sod_id IS NULL AND SOR.sor_order_number NOT IN ('WASTEMATERIAL01', '103247'))
         
         OPEN cur_Get_Completed_Shipping
         FETCH NEXT FROM cur_Get_Completed_Shipping 
         INTO @ORDER_ID 
         
         WHILE @@FETCH_STATUS = 0
         BEGIN
         	INSERT INTO @SHIPPING_ORDER_LIST                                     
            EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Shipping_Order_Data_From_TTS @ORDER_ID, 'P', NULL
            
         	FETCH NEXT FROM cur_Get_Completed_Shipping 
            INTO @ORDER_ID 
         END
         
         CLOSE cur_Get_Completed_Shipping
         DEALLOCATE cur_Get_Completed_Shipping                             

         IF NOT EXISTS(SELECT 1 FROM @SHIPPING_ORDER_LIST) 
         BEGIN
            COMMIT TRANSACTION
            RETURN
         END
         
         UPDATE Shipping_Order_List
         SET sor_status = 'P'
         WHERE sor_status IN ('O', 'M')
           AND sor_order_number IN (SELECT ORDER_ID FROM @SHIPPING_ORDER_LIST)                                                        
                                                     
         DECLARE cur_Get_Shipping_Data_From_TTSV2 CURSOR FOR 
         SELECT ORDER_ID 
         FROM @SHIPPING_ORDER_LIST
         
         OPEN cur_Get_Shipping_Data_From_TTSV2
         FETCH NEXT FROM cur_Get_Shipping_Data_From_TTSV2 
         INTO @ORDER_ID 
         
         WHILE @@FETCH_STATUS = 0
         BEGIN
            INSERT INTO @SHIPPING_AGGR                                                                       
            EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Aggregations_From_TTS @ORDER_ID
            
         	FETCH NEXT FROM cur_Get_Shipping_Data_From_TTSV2 
            INTO @ORDER_ID 
         END
         
         CLOSE cur_Get_Shipping_Data_From_TTSV2
         DEALLOCATE cur_Get_Shipping_Data_From_TTSV2
                   

         INSERT INTO Shipping_Order_Details
               (sod_sor_id,
                sod_sscc)                         
         SELECT DISTINCT 
                SOR.sor_id,
                CASE LEN(SSCC)
                  WHEN 20 THEN SSCC
                  ELSE '00' + SSCC
                END
         FROM @SHIPPING_AGGR AGG
         INNER JOIN Shipping_Order_List SOR ON (SOR.sor_order_number = AGG.SHIPPING_ORDER)
         LEFT JOIN Shipping_Order_Details SOD WITH (NOLOCK) ON (SOD.sod_sscc = CASE LEN(SSCC) WHEN 20 THEN SSCC ELSE '00' + SSCC END)
         WHERE SSCC <> 'NO CONTAINER'
           AND SOD.sod_id IS NULL
         UNION
         SELECT DISTINCT 
                SOR.sor_id,
                CASE LEN(PACKAGE_CODE)
                  WHEN 20 THEN PACKAGE_CODE
                  ELSE '00' + PACKAGE_CODE
                END
         FROM @SHIPPING_AGGR AGG
         INNER JOIN Shipping_Order_List SOR ON (SOR.sor_order_number = AGG.SHIPPING_ORDER)
         LEFT JOIN Shipping_Order_Details SOD WITH (NOLOCK) ON (SOD.sod_sscc = CASE LEN(PACKAGE_CODE) WHEN 20 THEN PACKAGE_CODE ELSE '00' + PACKAGE_CODE END)
         WHERE SSCC = 'NO CONTAINER'
           AND SOD.sod_id IS NULL
         
         
         INSERT INTO Package_Aggregations
               (pag_pck_id,
                pag_sscc)                   
         SELECT PCK.pck_id,
                CASE LEN(AGG.SSCC)
                  WHEN 20 THEN AGG.SSCC
                  ELSE '00' + AGG.SSCC
                END
         FROM @SHIPPING_AGGR AGG
         INNER JOIN Package_List PCK ON (PCK.pck_code = AGG.PACKAGE_CODE)
         LEFT JOIN Package_Aggregations PAG WITH (NOLOCK) ON (PAG.pag_sscc = CASE LEN(SSCC) WHEN 20 THEN SSCC ELSE '00' + SSCC END)
         WHERE SSCC <> 'NO CONTAINER'
           AND PAG.pag_id IS NULL        
         UNION 
         SELECT PCK.pck_id,
                CASE LEN(AGG.PACKAGE_CODE)
                  WHEN 20 THEN AGG.PACKAGE_CODE
                  ELSE '00' + AGG.PACKAGE_CODE
                END
         FROM @SHIPPING_AGGR AGG
         INNER JOIN Package_List PCK ON (PCK.pck_sscc = '00' + AGG.PACKAGE_CODE)
         LEFT JOIN Package_Aggregations PAG WITH (NOLOCK) ON (PAG.pag_sscc = CASE LEN(PACKAGE_CODE) WHEN 20 THEN PACKAGE_CODE ELSE '00' + PACKAGE_CODE END)
         WHERE SSCC = 'NO CONTAINER'
           AND PAG.pag_id IS NULL     
      END    
      ELSE
      BEGIN
      	INSERT INTO @SHIPPING_ORDER_LIST                                     
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Shipping_Order_Data_From_TTS @order_number, NULL, NULL
         
         INSERT INTO @SHIPPING_AGGR                                                                       
         EXEC TTS2.TTS_Plant.dbo.sp_wms_Get_Aggregations_From_TTS @order_number
            
         INSERT INTO Shipping_Order_List
               (sor_order_number,
                sor_com_id,
                sor_account_code,
                sor_status,
                sor_invoice_number,
                sor_invoice_date,
                sor_creation_date,
                sor_completion_date)                      
         SELECT SHP.ORDER_ID,
                CASE MOM.mom_db_code 
                  WHEN 4 THEN 1 
                  WHEN 6 THEN 2
                END,
                ISNULL(AMR.amr_account_code, CUS.TB073_CODE),
                SHP.STATUS_ID,
                MOM.mom_document_number,
                MOM.mom_document_date,
                SHP.CREATION_DATE,
                GETDATE()
         FROM @SHIPPING_ORDER_LIST SHP
         INNER JOIN TTS2.TTS_Plant.dbo.TB073_WH_CUSTOMERS CUS ON (CUS.TB073_CUSTOMER_ID = SHP.CUSTOMER_ID)
         LEFT JOIN TESTTCP.GENERAL.dbo.Movement_Master MOM ON (CAST(MOM.mom_parameter_2 AS VARCHAR(20)) = SHP.ORDER_ID)
         LEFT JOIN Account_Master AMR ON (AMR.amr_id = MOM.mom_account_id)
         WHERE SHP.ORDER_ID NOT IN (SELECT sor_order_number FROM Shipping_Order_List)  
           AND MOM.mom_movement_type = 12
           AND MOM.mom_movement_direction = 2   
           
         INSERT INTO Shipping_Order_Details
               (sod_sor_id,
                sod_sscc)                         
         SELECT DISTINCT 
                SOR.sor_id,
                CASE LEN(SSCC)
                  WHEN 20 THEN SSCC
                  ELSE '00' + SSCC
                END
         FROM @SHIPPING_AGGR AGG
         INNER JOIN Shipping_Order_List SOR ON (SOR.sor_order_number = AGG.SHIPPING_ORDER)
         LEFT JOIN Shipping_Order_Details SOD WITH (NOLOCK) ON (SOD.sod_sscc = CASE LEN(SSCC) WHEN 20 THEN SSCC ELSE '00' + SSCC END)
         WHERE SSCC <> 'NO CONTAINER'
           AND SOD.sod_id IS NULL
         UNION
         SELECT DISTINCT 
                SOR.sor_id,
                CASE LEN(PACKAGE_CODE)
                  WHEN 20 THEN PACKAGE_CODE
                  ELSE '00' + PACKAGE_CODE
                END
         FROM @SHIPPING_AGGR AGG
         INNER JOIN Shipping_Order_List SOR ON (SOR.sor_order_number = AGG.SHIPPING_ORDER)
         LEFT JOIN Shipping_Order_Details SOD WITH (NOLOCK) ON (SOD.sod_sscc = CASE LEN(PACKAGE_CODE) WHEN 20 THEN PACKAGE_CODE ELSE '00' + PACKAGE_CODE END)
         WHERE SSCC = 'NO CONTAINER'
           AND SOD.sod_id IS NULL
         
         
         INSERT INTO Package_Aggregations
               (pag_pck_id,
                pag_sscc)                   
         SELECT PCK.pck_id,
                CASE LEN(AGG.SSCC)
                  WHEN 20 THEN AGG.SSCC
                  ELSE '00' + AGG.SSCC
                END
         FROM @SHIPPING_AGGR AGG
         INNER JOIN Package_List PCK ON (PCK.pck_code = AGG.PACKAGE_CODE)
         LEFT JOIN Package_Aggregations PAG WITH (NOLOCK) ON (PAG.pag_sscc = CASE LEN(SSCC) WHEN 20 THEN SSCC ELSE '00' + SSCC END)
         WHERE SSCC <> 'NO CONTAINER'
           AND PAG.pag_id IS NULL        
         UNION 
         SELECT PCK.pck_id,
                CASE LEN(AGG.PACKAGE_CODE)
                  WHEN 20 THEN AGG.PACKAGE_CODE
                  ELSE '00' + AGG.PACKAGE_CODE
                END
         FROM @SHIPPING_AGGR AGG
         INNER JOIN Package_List PCK ON (PCK.pck_sscc = '00' + AGG.PACKAGE_CODE)
         LEFT JOIN Package_Aggregations PAG WITH (NOLOCK) ON (PAG.pag_sscc = CASE LEN(PACKAGE_CODE) WHEN 20 THEN PACKAGE_CODE ELSE '00' + PACKAGE_CODE END)
         WHERE SSCC = 'NO CONTAINER'
           AND PAG.pag_id IS NULL                
      
      END
   END TRY
   BEGIN CATCH
      DECLARE @ERROR_MESSAGE NVARCHAR(2048)
      SET @ERROR_MESSAGE = ERROR_MESSAGE()
      RAISERROR(N'Hata = %s', 16, 1, @ERROR_MESSAGE)       
      ROLLBACK TRANSACTION
      RETURN
   END CATCH
   
   COMMIT TRANSACTION
GO

/****** Object: Stored Procedure [dbo].[Global_Error_List_Insert]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Global_Error_List_Insert]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Global_Error_List_Insert]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Global_Error_List_Insert] 
   @erl_error_type        CHAR(2),
   @erl_error_code        CHAR(5),
   @erl_error_message     NVARCHAR(250),
   @erl_error_description NVARCHAR(250)
AS   
/*
{******************************************************************************}
{  Amaç         : Hata kodlarının kaydedilmesi.                                }
{																										 }
{  Param. Gelen :                                                          	 }
{																										 }
{  Açıklama     :                       													 }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     15/03/2012  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/      
   IF EXISTS(SELECT 1
             FROM Global_Error_List
             WHERE erl_error_code = @erl_error_code)
   BEGIN
      UPDATE Global_Error_List
      SET erl_error_type = @erl_error_type,
          erl_error_message = @erl_error_message,
          erl_error_description = @erl_error_description
      WHERE erl_error_code = @erl_error_code        
   END
   ELSE
   BEGIN
      INSERT INTO Global_Error_List
             (erl_error_type,
              erl_error_code,
              erl_error_message,         
              erl_error_description)
      VALUES (@erl_error_type,
              @erl_error_code,
              @erl_error_message,         
              @erl_error_description)   
   END
GO

/****** Object: Stored Procedure [dbo].[ITS_Sales_Control]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ITS_Sales_Control]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[ITS_Sales_Control]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ITS_Sales_Control]
   @gtin     VARCHAR(14),
   @batch_no VARCHAR(10),
   @origin   INT = 1,
   @rowcount INT = 5000 
AS    
   SELECT *
   FROM (SELECT MMR.mmr_gtin,
                PCK.pck_code,
                PCK.pck_status,
                CONVERT(SMALLDATETIME, CONVERT(VARCHAR(10), ORD.ord_expiry_date, 120)) AS expiry_date,
                ORD.ord_batch_no,
                ROW_NUMBER() OVER(ORDER BY PCK.pck_code) AS ID
         FROM Package_List PCK
         INNER JOIN Order_List ORD ON (ORD.ord_order_id = PCK.pck_order_id)
         INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id)
         WHERE MMR.mmr_gtin = @gtin
           AND ord_batch_no = @batch_no) P
   WHERE ID BETWEEN @origin AND @origin + @rowcount - 1
GO

/****** Object: Stored Procedure [dbo].[ITS_Sales_Control_Count]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ITS_Sales_Control_Count]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[ITS_Sales_Control_Count]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ITS_Sales_Control_Count]
   @gtin     VARCHAR(14),
   @batch_no VARCHAR(10)
AS    
   SELECT COUNT(PCK.pck_code) AS count_of_package
   FROM Package_List PCK
   INNER JOIN Order_List ORD ON (ORD.ord_order_id = PCK.pck_order_id)
   INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id)
   WHERE MMR.mmr_gtin = @gtin
     AND ord_batch_no = @batch_no
GO

/****** Object: Stored Procedure [dbo].[Nerede]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Nerede]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Nerede]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROCEDURE [dbo].[Nerede]
		@Str VARCHAR(1000) = null,
		@Str2 VARCHAR(1000) = null
AS
	SET NOCOUNT ON
	IF @Str2 IS NULL
	SELECT @Str = 'SELECT SUBSTRING( O.name, 1, 100 ) AS Object, Count(*) as Occurences, ' +
		'CASE ' +
		' WHEN O.xtype = ''D'' THEN ''Default'' ' +
		' WHEN O.xtype = ''F'' THEN ''Foreign Key'' ' +
		' WHEN O.xtype = ''P'' THEN ''Stored Procedure'' ' +
		' WHEN O.xtype = ''PK'' THEN ''Primary Key'' ' +
		' WHEN O.xtype = ''S'' THEN ''System Table'' ' +
		' WHEN O.xtype = ''TR'' THEN ''Trigger'' ' +
		' WHEN O.xtype = ''U'' THEN ''User Table'' ' +
		' WHEN O.xtype = ''V'' THEN ''View'' ' +
		'END AS Type ' +
		'FROM SYSCOMMENTS C JOIN SYSOBJECTS O ON C.id = O.id ' +
		'WHERE PATINDEX( ''%'  + @Str + '%'', C.text ) > 0 ' +
		'GROUP BY O.Name, O.xtype ' +
		'ORDER BY O.xtype, O.name'

	ELSE

	SELECT @Str = 'SELECT SUBSTRING( O.name, 1, 100 ) AS Object, Count(*) as Occurences, ' +
		'CASE ' +
		' WHEN O.xtype = ''D'' THEN ''Default'' ' +
		' WHEN O.xtype = ''F'' THEN ''Foreign Key'' ' +
		' WHEN O.xtype = ''P'' THEN ''Stored Procedure'' ' +
		' WHEN O.xtype = ''PK'' THEN ''Primary Key'' ' +
		' WHEN O.xtype = ''S'' THEN ''System Table'' ' +
		' WHEN O.xtype = ''TR'' THEN ''Trigger'' ' +
		' WHEN O.xtype = ''U'' THEN ''User Table'' ' +
		' WHEN O.xtype = ''V'' THEN ''View'' ' +
		'END AS Type ' +
		'FROM SYSCOMMENTS C JOIN SYSOBJECTS O ON C.id = O.id ' +
		'WHERE PATINDEX( ''%'  + @Str + '%'', C.text ) > 0  AND PATINDEX( ''%'  + @Str2 + '%'', C.text ) = 0' +
		'GROUP BY O.Name, O.xtype ' +
		'ORDER BY O.xtype, O.name'

	EXECUTE( @Str )
GO

/****** Object: Stored Procedure [dbo].[Order_Detail]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order_Detail]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Order_Detail]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Order_Detail]
   @order_id VARCHAR(20)
AS
   SELECT ORD.ord_order_id,
          ORD.ord_batch_no,
          MMR.mmr_item_no,
          dbo.TRK(MMR.mmr_item_name) AS mmr_item_name,
          MMR.mmr_gtin,
          MMR.mmr_registered_to,
          ORD.ord_target_quantity,
          CONVERT(VARCHAR(10), ORD.ord_expiry_date, 103) AS ord_expiry_date,
          CONVERT(VARCHAR(10), ORD.ord_order_start_date, 120) AS start_date,
          CONVERT(VARCHAR(10), ORD.ord_expiry_date, 120) AS expiry_date,
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id = ORD.ord_order_id
             AND pck_status = 'W'
             AND pck_status_id = 10) AS unsent_quantity,
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id = ORD.ord_order_id
             AND pck_status <> 'W') AS sent_quantity,             
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id = ORD.ord_order_id
             AND pck_status_id = 10) AS approval_quantity,             
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id = ORD.ord_order_id
             AND pck_status_id <> 10) AS disapproval_quantity,                          
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id = ORD.ord_order_id) AS total_package_quantity,
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id = ORD.ord_order_id
             AND pck_status = 'D') AS made_of_deactivation_quantity,        
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id = ORD.ord_order_id
             AND pck_status_id = '98'
             AND pck_status = 'P') AS deactivation_quantity,                                       
          ISNULL((SELECT TOP 1 1
                  FROM Package_List 
                  WHERE pck_order_id = ORD.ord_order_id
                    AND pck_sscc IS NOT NULL), 0) AS sscc_found,
          (SELECT COUNT(DISTINCT pck_sscc)
           FROM Package_List
           WHERE pck_order_id = ORD.ord_order_id) AS case_quantity,
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id = ORD.ord_order_id
             AND pck_sscc IS NULL) AS not_case_quantity
             
   FROM Order_List ORD
   INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id)      
   WHERE ORD.ord_order_id = @order_id
GO

/****** Object: Stored Procedure [dbo].[Order_List_Browse]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order_List_Browse]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Order_List_Browse]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Order_List_Browse]
AS
--EXEC Get_Data_From_WMS
    
   SELECT *,
          CAST(0 AS BIT) AS checked,
          NULL AS scheduled_time
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
         LEFT JOIN Line_List LIN WITH (NOLOCK) ON (LIN.lin_id = ORD.ord_line_id)) T
   WHERE T.unsent_quantity > 0
   ORDER BY ord_order_id --DESC
GO

/****** Object: Stored Procedure [dbo].[Order_List_Browse_For_Additional_Production_Order_Insert]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order_List_Browse_For_Additional_Production_Order_Insert]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Order_List_Browse_For_Additional_Production_Order_Insert]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Order_List_Browse_For_Additional_Production_Order_Insert] --NULL, '22226'
   @day      INT = NULL,
   @order_id VARCHAR(20) = NULL
AS   
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
GO

/****** Object: Stored Procedure [dbo].[Order_List_Browse_For_Control]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order_List_Browse_For_Control]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Order_List_Browse_For_Control]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Order_List_Browse_For_Control]
AS
   SELECT pck_order_id,
          MMR.mmr_gtin,
          ORD.ord_batch_no,
          CONVERT(SMALLDATETIME, CONVERT(VARCHAR(10), ORD.ord_expiry_date, 120)) AS expiry_date,
          MAX(pck_code) AS pck_code
   FROM Package_List PCK
   INNER JOIN Order_List ORD ON (ORD.ord_order_id = PCK.pck_order_id)
   INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id)
   WHERE pck_status = 'P'
     AND EXISTS(SELECT 1
                FROM Package_Movement_Master 
                WHERE pmm_order_id = pck_order_id
                  AND pmm_environment = 'G')
   GROUP BY pck_order_id,
            MMR.mmr_gtin,
            ORD.ord_batch_no,
            ORD.ord_expiry_date
GO

/****** Object: Stored Procedure [dbo].[Order_List_Browse_For_Deactivation]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order_List_Browse_For_Deactivation]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Order_List_Browse_For_Deactivation]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Order_List_Browse_For_Deactivation]
AS    
   SELECT --TOP 100
          pck_order_id, 
          COUNT(pck_id) AS count_of_pck
   FROM Package_List
   WHERE pck_status_id = 98
     AND pck_order_id <> '24600'
   GROUP BY pck_order_id
   ORDER BY pck_order_id
GO

/****** Object: Stored Procedure [dbo].[Order_List_Browse_For_Referable_To_AGE]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order_List_Browse_For_Referable_To_AGE]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Order_List_Browse_For_Referable_To_AGE]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Order_List_Browse_For_Referable_To_AGE] 
   @day TINYINT = 7
AS   
	SELECT TB022_ORDER_ID,
	       mmr_item_no,
	       dbo.TRK(mmr_item_name) AS mmr_item_name,
	       mmr_gtin,
	       TB022_TARGET_QTY,
	       TB022_PK_BATCH_NO, 
	       TB022_EXPIRY_DATE,
	       (SELECT TB026_USC_REQUIRED
           FROM TTS.TTS.dbo.TB026_TT_ORDER_ML 
           WHERE TB026_ORDER_ID = TB022_ORDER_ID) AS created_usc_count
   FROM TTS.TTS.dbo.TB022_TTORDERS 
   INNER JOIN TTS.TTS.dbo.TB020_ITEM_MASTER ON (TB020_ITEM_ID = TB022_ITEM_ID)
   INNER JOIN Material_Master ON (mmr_gtin = TB020_GTIN)
   WHERE TB022_ORDER_STATUS_ID NOT IN (50, 90)
     AND TB022_REAL_START_DATE > GETDATE() - @day
     AND TB022_ORDER_ID NOT IN (SELECT URETIMEMRI_ACIKLAMA COLLATE database_default FROM KAREKOD..URETIMEMRI)
	ORDER BY TB022_ORDER_ID
GO

/****** Object: Stored Procedure [dbo].[Order_List_Browse_For_Search]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order_List_Browse_For_Search]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Order_List_Browse_For_Search]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Order_List_Browse_For_Search]
/*
{******************************************************************************}
{  Amaç         : Malzeme ve seri bazında üretim emirlerini aramak             }
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
   SELECT ORD.ord_order_id,
          ORD.ord_batch_no,
          LIN.lin_description,
          MMR.mmr_item_no,
          dbo.TRK(MMR.mmr_item_name) AS mmr_item_name,
          MMR.mmr_item_no + ' / ' + dbo.TRK(MMR.mmr_item_name) AS item_information,
          MMR.mmr_gtin,
          ORD.ord_target_quantity,
          ORD.ord_order_start_date,
          ORD.ord_order_end_date,
          ORD.ord_expiry_date
   FROM Order_List ORD WITH (NOLOCK)
   INNER JOIN Material_Master MMR WITH (NOLOCK) ON (MMR.mmr_id = ORD.ord_mmr_id) 
   INNER JOIN Line_List LIN WITH (NOLOCK) ON (LIN.lin_id = ORD.ord_line_id)
   WHERE PATINDEX('%[_]%', ORD.ord_order_id) = 0
GO

/****** Object: Stored Procedure [dbo].[Package_List_All_Update_For_Deactivation]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_List_All_Update_For_Deactivation]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Package_List_All_Update_For_Deactivation]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_List_All_Update_For_Deactivation] 
   @pck_order_id VARCHAR(20)
AS      
   UPDATE Package_List
   SET pck_status_id = 98,                            
       pck_previous_status_id = CASE pck_status_id
                                 WHEN 98 THEN pck_previous_status_id                     
                                 ELSE pck_status_id 
                                END
   WHERE pck_order_id = @pck_order_id
     AND pck_status = 'P'
   
   IF @@ERROR <> 0 OR @@ROWCOUNT = 0
   BEGIN
      RAISERROR('Ambalaj detay bilgisi güncellenemedi!', 16, 1)
      RETURN
   END
GO

/****** Object: Stored Procedure [dbo].[Package_List_Browse]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_List_Browse]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Package_List_Browse]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_List_Browse] --'30638', null, null, '123'
   @order_id  VARCHAR(20),
   @status    CHAR(1) = NULL,
   @status_id TINYINT = NULL,
   @pck_code  VARCHAR(32) = '',      
   @pck_sscc  VARCHAR(20) = '',
   @usr_id    INT = NULL,
   @rowcount  INT = 100
WITH RECOMPILE   
AS
   IF @order_id IS NULL SET @rowcount = 100
   
   DECLARE @SQL NVARCHAR(MAX),
           @QUE NVARCHAR(MAX)
           
   SET @SQL = N'
   SELECT TOP (' + CAST(@rowcount AS VARCHAR) + N')
          CAST(0 AS BIT) AS checked,
          pck_order_id,
          pck_id,
          pck_code,
          pck_status_id,
          PCK.pck_timestamp,
          PST.pst_description,
          CASE pck_status
            WHEN ''W'' THEN N''Beklemede''
            WHEN ''P'' THEN N''Üretim Bildirimi Yapıldı''
            WHEN ''D'' THEN N''Deaktive Edildi''
            WHEN ''S'' THEN N''Satıldı''
            WHEN ''I'' THEN N''İhracat Yapıldı''
          END AS status,
          ISNULL(dbo.TRK(dbo.Fn_Sifre_Coz(USR.usr_full_name)), ''TTS'') AS inserted_user,
          pck_original_order_id,
          CASE pck_was_printed
            WHEN 0 THEN N''Basılmadı''
            WHEN 1 THEN N''Basıldı''
          END AS was_printed,
          ISNULL(pck_source, N''ELLE GİRİŞ'') AS pck_source,
          pck_sscc
   FROM Package_List PCK WITH (NOLOCK)
   INNER JOIN Package_Status PST ON (PST.pst_status_id = PCK.pck_status_id)
   LEFT JOIN TESTTCP.SECURITY.dbo.Users USR ON (USR.usr_id = PCK.pck_usr_id) '
   
   SET @QUE = N''
   IF @order_id IS NOT NULL
      SET @QUE = @QUE + N'pck_order_id = ''' + @order_id + N''' AND '
   IF @status IS NOT NULL      
      SET @QUE = @QUE + N'pck_status = ''' + @status + N''' AND '
   IF @status_id IS NOT NULL      
      SET @QUE = @QUE + N'pck_status_id = ' + CAST(@status_id AS VARCHAR) + N' AND '
   IF @usr_id IS NOT NULL      
      SET @QUE = @QUE + N'pck_usr_id = ' + CAST(@usr_id AS VARCHAR) + N' AND '
   IF @pck_code <> ''
      SET @QUE = @QUE + N'pck_code LIKE ''\'' + ''' + @pck_code + N''' + ''%'' ESCAPE ''\'' AND '      
   IF @pck_sscc <> ''
      SET @QUE = @QUE + N'pck_sscc = ''' + @pck_sscc + N''' AND '
   
   IF @QUE <> '' SET @QUE = LEFT(@QUE, LEN(@QUE) - 4) 
   IF @QUE <> '' SET @SQL = @SQL + N'WHERE ' + @QUE + N' ORDER BY pck_code'     
     
   EXEC sp_executesql @SQL
GO

/****** Object: Stored Procedure [dbo].[Package_List_Browse_For_Deaktivation]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_List_Browse_For_Deaktivation]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Package_List_Browse_For_Deaktivation]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_List_Browse_For_Deaktivation]
   @order_id  VARCHAR(20),
   @origin    INT = NULL,
   @rowcount  INT = NULL      
AS   
   SET ROWCOUNT 0  
   
   SELECT IDENTITY(INT, 1, 1) AS ID,
          CAST(pck_id AS INT) AS pck_id,
          pck_code
   INTO #TEMP_Package_List          
   FROM Package_List 
   WHERE pck_order_id = @order_id
     AND pck_status_id = 98
     
   SET @origin = ISNULL(@origin, 0)     
   
   IF @rowcount IS NOT NULL
   BEGIN
      SET ROWCOUNT @rowcount          
        
      SELECT pck_id, 
             pck_code 
      FROM #TEMP_Package_List
      WHERE ID > @origin
   END
   ELSE SELECT pck_id, pck_code FROM #TEMP_Package_List
   
   DROP TABLE #TEMP_Package_List
GO

/****** Object: Stored Procedure [dbo].[Package_List_Browse_For_Sending]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_List_Browse_For_Sending]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Package_List_Browse_For_Sending]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_List_Browse_For_Sending] --'93F43E64', 'W', 1000, 1000
   @order_id  VARCHAR(20),
   @status    CHAR(1) = 'W',
   @origin    INT = NULL,
   @rowcount  INT = NULL      
AS

   
   SET ROWCOUNT 0  
   
   SELECT IDENTITY(INT, 1, 1) AS ID,
          CAST(pck_id AS INT) AS pck_id,
          pck_code
   INTO #TEMP_Package_List          
   FROM Package_List 
   WHERE pck_order_id = @order_id
     AND pck_status = @status
     AND pck_status_id = 10
     
   SET @origin = ISNULL(@origin, 0)     
   
   IF @rowcount IS NOT NULL
   BEGIN
      SET ROWCOUNT @rowcount          
        
      SELECT pck_id, 
             pck_code 
      FROM #TEMP_Package_List
      WHERE ID > @origin
   END
   ELSE SELECT pck_id, pck_code FROM #TEMP_Package_List
   
   DROP TABLE #TEMP_Package_List
GO

/****** Object: Stored Procedure [dbo].[Package_List_Delete]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_List_Delete]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Package_List_Delete]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_List_Delete] 
   @pck_id    INT,
   @operation CHAR(1) = 'U'
AS
   IF @operation = 'U'
   BEGIN
      IF EXISTS(SELECT 1
                FROM Package_List
                WHERE pck_id = @pck_id
                  AND pck_status <> 'W')
      BEGIN
         RAISERROR('070103-DSD-0001 - Bildirim durumu değişmiş bir ambalajın geçerlilik durumu güncellenemez!', 16, 1)
         RETURN            
      END
                        
      UPDATE Package_List
      SET pck_status_id = 99,
          pck_previous_status_id = pck_status_id  
      WHERE pck_id = @pck_id
      
      IF @@ERROR <> 0 OR @@ROWCOUNT = 0
      BEGIN
         RAISERROR('070103-DSD-0002 - Ambalaj detay bilgisi güncellenemedi!', 16, 1)
         RETURN
      END
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

/****** Object: Stored Procedure [dbo].[Package_List_Insert]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_List_Insert]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Package_List_Insert]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_List_Insert] 
   @pck_order_id  VARCHAR(20),
   @pck_code      VARCHAR(32),
   @usr_id        INT
AS
   IF EXISTS(SELECT 1
             FROM Package_List
             WHERE pck_code = @pck_code)
   BEGIN
      RAISERROR('070103-DSI-0001 - Ambalaj numarası mevcut. Tekrar eklenemez!', 16, 1)
      RETURN
   END
                
   INSERT INTO Package_List
          (pck_order_id,
           pck_code,
           pck_status_id,         
           pck_timestamp,
           pck_is_filled,
           pck_sync_date,
           pck_status,
           pck_usr_id)
   VALUES (@pck_order_id,
           @pck_code,
           10,
           GETDATE(),
           -1,
           GETDATE(),
           'W',
           @usr_id)
   
   IF @@ERROR <> 0 
   BEGIN
      RAISERROR('070103-DSI-0002 - Ambalaj detay bilgisi eklenemedi!', 16, 1)
      RETURN
   END
   
   RETURN  SCOPE_IDENTITY()
GO

/****** Object: Stored Procedure [dbo].[Package_List_Insert_From_Not_Printed_Packages]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_List_Insert_From_Not_Printed_Packages]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Package_List_Insert_From_Not_Printed_Packages]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_List_Insert_From_Not_Printed_Packages]
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
      RAISERROR('Ambalajlar eklenirken bir sorun oluştu ve eklenemedi!', 16, 1)
      RETURN 
   END CATCH
GO

/****** Object: Stored Procedure [dbo].[Package_List_Not_Printed_Browse]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_List_Not_Printed_Browse]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Package_List_Not_Printed_Browse]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_List_Not_Printed_Browse] 
   @order_id  VARCHAR(20)
AS
   SELECT CAST(0 AS BIT) AS checked,
          *
   FROM Package_List_Not_Printed WITH (NOLOCK)
   WHERE (pcp_order_id = @order_id OR pcp_order_id LIKE @order_id + '_%')
     AND pcp_code NOT IN (SELECT pck_code FROM Package_List WHERE pck_order_id = @order_id)
   ORDER BY pcp_order_id
GO

/****** Object: Stored Procedure [dbo].[Package_List_Update]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_List_Update]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Package_List_Update]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_List_Update] 
   @pck_id        INT,
   @pck_status_id SMALLINT
AS
   IF EXISTS(SELECT 1
             FROM Package_List
             WHERE pck_id = @pck_id
               AND pck_status <> 'W'
               AND @pck_status_id <> 98
               AND pck_status_id <> 98)                              
   BEGIN
      RAISERROR('070103-DSU-0001 - Bildirim durumu değişmiş bir ambalajın geçerlilik durumu güncellenemez!', 16, 1)
      RETURN            
   END
   
   IF EXISTS(SELECT 1
             FROM Package_List
             WHERE pck_id = @pck_id
               AND pck_status = 'W'
               AND @pck_status_id = 98
               AND pck_status_id <> 98)                              
   BEGIN
      RAISERROR('070103-DSU-0002 - Üretim bildirimi yapılmamış bir ambalaj ''DEAKTİVE EDİLECEK'' durumuna getirilemez!', 16, 1)
      RETURN            
   END
   
   IF EXISTS(SELECT 1
             FROM Package_List
             WHERE pck_id = @pck_id
               AND pck_status IN ('D', 'S'))
   BEGIN
      RAISERROR('070103-DSU-0003 - Deaktive edilmiş ya da satılmış bir ambalaj güncellenemez!', 16, 1)
      RETURN            
   END
         
   UPDATE Package_List
   SET pck_status_id = CASE 
                        WHEN pck_status_id = 98 AND @pck_status_id = 98 THEN pck_previous_status_id 
                        ELSE @pck_status_id
                       END,                            
       pck_previous_status_id = CASE 
                                 WHEN pck_previous_status_id IS NULL THEN pck_status_id
                                 WHEN pck_previous_status_id = @pck_status_id THEN NULL
                                 ELSE pck_previous_status_id
                                END
   WHERE pck_id = @pck_id
   
   IF @@ERROR <> 0 OR @@ROWCOUNT = 0
   BEGIN
      RAISERROR('070103-DSU-0004 - Ambalaj detay bilgisi güncellenemedi!', 16, 1)
      RETURN
   END
GO

/****** Object: Stored Procedure [dbo].[Package_List_Update_First_Status]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_List_Update_First_Status]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Package_List_Update_First_Status]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[Package_List_Update_First_Status]
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

/****** Object: Stored Procedure [dbo].[Package_Movement_Detail_Batch_Insert]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_Movement_Detail_Batch_Insert]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Package_Movement_Detail_Batch_Insert]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_Movement_Detail_Batch_Insert]
   @pmd_pmm_id        INT,
   @pmd_response_code CHAR(5),
   @pmd_pck_ids       VARCHAR(4000)
AS
   DECLARE @I INT
   DECLARE @S VARCHAR(20)

   SET NOCOUNT ON 
   
	CREATE TABLE #pck_ids (pck_id INT)
   SET @I = 0
   SET @S = ''

   WHILE LEN(@pmd_pck_ids) > @I
   BEGIN
      SET @I = @I + 1
      IF (SUBSTRING(@pmd_pck_ids, @I, 1) = ',')
      BEGIN
         INSERT INTO #pck_ids
         SELECT CAST(@S AS INT)
			SET @S=''
         CONTINUE
      END
      SET  @S = @S + SUBSTRING(@pmd_pck_ids, @I, 1)
   END

   SET NOCOUNT OFF
   
   INSERT INTO Package_Movement_Detail
          (pmd_pmm_id,
           pmd_pck_id,
           pmd_response_code)
   SELECT  @pmd_pmm_id,
           pck_id,
           @pmd_response_code
   FROM #pck_ids           
           
   IF @@ROWCOUNT = 0 OR @@ERROR <> 0
   BEGIN
      RAISERROR('Hareket detay kaydı eklenemedi!', 16, 1)
      RETURN -1
   END  

   -- Satış bildirimi sonrası bildirim yapıldığı flagı set edilecek
   IF EXISTS(SELECT 1
             FROM Package_Movement_Master
             WHERE pmm_id = @pmd_pmm_id
               AND pmm_type = 'S')
   BEGIN
      DECLARE @sor_order_number NVARCHAR(20)
      SELECT @sor_order_number = pmm_order_id
      FROM Package_Movement_Master
      WHERE pmm_id = @pmd_pmm_id
      
      IF NOT EXISTS(SELECT 1
                    FROM dbo.fn_get_shipping_packages_with_aggregations(@sor_order_number) AGG
                    INNER JOIN Package_List PCK WITH (NOLOCK) ON (PCK.pck_id = AGG.package_id)
                    WHERE PCK.pck_status <> 'S')
      BEGIN
         UPDATE Shipping_Order_List
         SET sor_was_declaration = 2
         WHERE sor_order_number = @sor_order_number
      END
      ELSE IF EXISTS(SELECT 1
                     FROM dbo.fn_get_shipping_packages_with_aggregations(@sor_order_number) AGG
                     INNER JOIN Package_List PCK WITH (NOLOCK) ON (PCK.pck_id = AGG.package_id)
                     WHERE PCK.pck_status = 'S')  
      BEGIN
         UPDATE Shipping_Order_List
         SET sor_was_declaration = 1
         WHERE sor_order_number = @sor_order_number
      END                     
   END
      
   DROP TABLE #pck_ids
GO

/****** Object: Stored Procedure [dbo].[Package_Movement_Detail_Insert]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_Movement_Detail_Insert]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Package_Movement_Detail_Insert]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_Movement_Detail_Insert]
   @pmd_pmm_id        INT,
   @pmd_pck_id        INT,
   @pmd_response_code CHAR(5)
AS
   INSERT INTO Package_Movement_Detail
          (pmd_pmm_id,
           pmd_pck_id,
           pmd_response_code)
   VALUES (@pmd_pmm_id,
           @pmd_pck_id,
           @pmd_response_code)           
           
   IF @@ROWCOUNT = 0 OR @@ERROR <> 0
   BEGIN
      RAISERROR('Hareket detay kaydı eklenemedi!', 16, 1)
      RETURN -1
   END
GO

/****** Object: Stored Procedure [dbo].[Package_Movement_Master_Browse]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_Movement_Master_Browse]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Package_Movement_Master_Browse]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_Movement_Master_Browse]
   @begin_date    DATETIME = NULL,
   @end_date      DATETIME = NULL,
   @item_name     VARCHAR(50) = NULL,
   @order_id      VARCHAR(20) = NULL,
   @rowcount      INT = NULL,   
   @parent_id     INT = NULL,
   @parent_ids    VARCHAR(1000) = NULL,
   @types         VARCHAR(100) = NULL,
   @is_scheduled  BIT = NULL
AS
   DECLARE @I INT
   DECLARE @S VARCHAR(20)

   SET NOCOUNT ON 
   
	DECLARE @tparent_ids TABLE (parent_id INT)
   SET @I = 0
   SET @S = ''

   WHILE LEN(@parent_ids) > @I
   BEGIN
      SET @I = @I + 1
      IF (SUBSTRING(@parent_ids, @I, 1) = ',')
      BEGIN
         INSERT INTO @tparent_ids
         SELECT CAST(@S AS INT)
			SET @S=''
         CONTINUE
      END
      SET  @S = @S + SUBSTRING(@parent_ids, @I, 1)
   END

	DECLARE @ttypes TABLE ([type] CHAR(1))
   SET @I = 0
   SET @S = ''

   WHILE LEN(@types) > @I
   BEGIN
      SET @I = @I + 1
      IF (SUBSTRING(@types, @I, 1) = ',')
      BEGIN
         INSERT INTO @ttypes
         SELECT @S
			SET @S=''
         CONTINUE
      END
      SET  @S = @S + SUBSTRING(@types, @I, 1)
   END
   
   SET NOCOUNT OFF
   
   SET @rowcount = ISNULL(@rowcount, 100)   
   SET ROWCOUNT @rowcount
   
   SELECT @begin_date = CONVERT(DATETIME,(CONVERT(VARCHAR(10), @begin_date, 120)) + ' 00:00:01',120),
          @end_date = CONVERT(DATETIME,(CONVERT(VARCHAR(10), @end_date, 120)) + ' 23:59:59',120)
             
   SELECT pmm_id,
          pmm_key,
          pmm_order_id,
          CASE pmm_type
            WHEN 'P' THEN N'Üretim'
            WHEN 'D' THEN N'Deaktivasyon'
            WHEN 'S' THEN N'Satış'
            WHEN 'E' THEN N'İhracat'
            WHEN 'T' THEN N'Satış İptal'
            WHEN 'C' THEN N'PTS'
          END AS type,
          pmm_datetime,
          pmm_declaration_id,
          pmm_sending_file_name,
          pmm_coming_file_name,
          ORD.ord_batch_no,
          ORD.ord_expiry_date,
          MMR.mmr_item_no,
          dbo.TRK(MMR.mmr_item_name) AS mmr_item_name,
          CAST(N'' AS NVARCHAR(50)) AS account_name,
          dbo.TRK(dbo.Fn_Sifre_Coz(USR.usr_full_name)) AS usr_full_name,
          (SELECT err_error_message FROM Errors WHERE err_pmm_id = PMM.pmm_id) AS err_error_message,
          (SELECT COUNT(pmm_id) FROM Package_Movement_Master WHERE pmm_parent_id = PMM.pmm_parent_id) AS gonderilen_parca_adedi,
          (SELECT COUNT(pmm_id) FROM Package_Movement_Master WHERE pmm_parent_id = PMM.pmm_parent_id AND pmm_declaration_id IS NOT NULL) AS cevaplanan_parca_adedi,
          (SELECT COUNT(pmd_id) FROM Package_Movement_Detail WHERE pmd_pmm_id = PMM.pmm_id) AS toplam_gonderilen_ambalaj_adedi,
          (SELECT COUNT(pmd_id) FROM Package_Movement_Detail WHERE pmd_pmm_id = PMM.pmm_id AND pmd_response_code = '00000') AS kabul_edilen_ambalaj_adedi,
          (SELECT COUNT(pmd_id) FROM Package_Movement_Detail WHERE pmd_pmm_id = PMM.pmm_id AND pmd_response_code <> '00000') AS kabul_edilmeyen_ambalaj_adedi,
          (SELECT COUNT(pmd_id) FROM Package_Movement_Detail WHERE pmd_pmm_id = PMM.pmm_id AND pmd_response_code = '10007') AS daha_once_kaydedilmis_ambalaj_adedi
   FROM Package_Movement_Master PMM
   INNER JOIN Order_List ORD ON (ORD.ord_order_id = PMM.pmm_order_id AND PMM.pmm_type IN ('P', 'D'))   
   INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id) 
   LEFT JOIN TESTTCP.SECURITY.dbo.Users USR ON (USR.usr_id = PMM.pmm_usr_id)
   WHERE PMM.pmm_datetime BETWEEN ISNULL(@begin_date, PMM.pmm_datetime) AND ISNULL(@end_date, PMM.pmm_datetime)
     AND (ISNULL(@item_name, '') = '' OR MMR.mmr_item_name LIKE '\' + @item_name + '%' ESCAPE '\' )
     AND (ISNULL(@order_id, '') = '' OR PMM.pmm_order_id LIKE '\' + @order_id + '%' ESCAPE '\' )     
     AND (@parent_id IS NULL OR PMM.pmm_parent_id = @parent_id) 
     AND (@parent_ids IS NULL OR PMM.pmm_parent_id IN (SELECT parent_id FROM @tparent_ids))
     AND (@types IS NULL OR PMM.pmm_type IN (SELECT [type] FROM @ttypes))
     AND (@is_scheduled IS NULL OR ISNULL(PMM.pmm_is_scheduled, 0) = @is_scheduled)
   UNION
   SELECT pmm_id,
          pmm_key,
          pmm_order_id,
          CASE pmm_type
            WHEN 'P' THEN N'Üretim'
            WHEN 'D' THEN N'Deaktivasyon'
            WHEN 'S' THEN N'Satış'
            WHEN 'E' THEN N'İhracat'
            WHEN 'T' THEN N'Satış İptal'
            WHEN 'C' THEN N'PTS'
          END AS type,
          pmm_datetime,
          pmm_declaration_id,
          pmm_sending_file_name,
          pmm_coming_file_name,
          '' AS ord_batch_no,
          NULL AS ord_expiry_date,
          '' AS mmr_item_no,
          AMR.amr_account_code + ' / ' + dbo.TRK(AMR.amr_account_name) AS mmr_item_name,
          AMR.amr_account_code + ' / ' + dbo.TRK(AMR.amr_account_name) AS account_name,
          dbo.TRK(dbo.Fn_Sifre_Coz(USR.usr_full_name)) AS usr_full_name,
          (SELECT err_error_message FROM Errors WHERE err_pmm_id = PMM.pmm_id) AS err_error_message,
          (SELECT COUNT(pmm_id) FROM Package_Movement_Master WHERE pmm_parent_id = PMM.pmm_parent_id) AS gonderilen_parca_adedi,
          (SELECT COUNT(pmm_id) FROM Package_Movement_Master WHERE pmm_parent_id = PMM.pmm_parent_id AND pmm_declaration_id IS NOT NULL) AS cevaplanan_parca_adedi,
          (SELECT COUNT(pmd_id) FROM Package_Movement_Detail WHERE pmd_pmm_id = PMM.pmm_id) AS toplam_gonderilen_ambalaj_adedi,
          (SELECT COUNT(pmd_id) FROM Package_Movement_Detail WHERE pmd_pmm_id = PMM.pmm_id AND pmd_response_code = '00000') AS kabul_edilen_ambalaj_adedi,
          (SELECT COUNT(pmd_id) FROM Package_Movement_Detail WHERE pmd_pmm_id = PMM.pmm_id AND pmd_response_code <> '00000') AS kabul_edilmeyen_ambalaj_adedi,
          (SELECT COUNT(pmd_id) FROM Package_Movement_Detail WHERE pmd_pmm_id = PMM.pmm_id AND pmd_response_code = '10007') AS daha_once_kaydedilmis_ambalaj_adedi
   FROM Package_Movement_Master PMM
   INNER JOIN Shipping_Order_List SOR ON (SOR.sor_order_number = PMM.pmm_order_id)  
   INNER JOIN Account_Master AMR ON (AMR.amr_account_code = SOR.sor_account_code)
   LEFT JOIN TESTTCP.SECURITY.dbo.Users USR ON (USR.usr_id = PMM.pmm_usr_id)   
   WHERE PMM.pmm_datetime BETWEEN ISNULL(@begin_date, PMM.pmm_datetime) AND ISNULL(@end_date, PMM.pmm_datetime)
     AND (ISNULL(@item_name, '') = '' OR dbo.TRK(AMR.amr_account_name) LIKE @item_name + '%' ESCAPE '\' )
     AND (ISNULL(@order_id, '') = '' OR SOR.sor_order_number LIKE '\' + @order_id + '%' ESCAPE '\' )     
     AND (@parent_id IS NULL OR PMM.pmm_parent_id = @parent_id) 
     AND (@parent_ids IS NULL OR PMM.pmm_parent_id IN (SELECT parent_id FROM @tparent_ids)) 
     AND (@types IS NULL OR PMM.pmm_type IN (SELECT [type] FROM @ttypes))
     AND (@is_scheduled IS NULL OR ISNULL(PMM.pmm_is_scheduled, 0) = @is_scheduled)
   UNION
   SELECT pmm_id,
          pmm_key,
          pmm_order_id,
          CASE pmm_type
            WHEN 'P' THEN N'Üretim'
            WHEN 'D' THEN N'Deaktivasyon'
            WHEN 'S' THEN N'Satış'
            WHEN 'E' THEN N'İhracat'
            WHEN 'T' THEN N'Satış İptal'
            WHEN 'C' THEN N'PTS'
          END AS type,
          pmm_datetime,
          pmm_declaration_id,
          pmm_sending_file_name,
          pmm_coming_file_name,
          '' AS ord_batch_no,
          NULL AS ord_expiry_date,
          '' AS mmr_item_no,
          AMR.amr_account_code + ' / ' + dbo.TRK(AMR.amr_account_name) AS mmr_item_name,
          AMR.amr_account_code + ' / ' + dbo.TRK(AMR.amr_account_name) AS account_name,
          dbo.TRK(dbo.Fn_Sifre_Coz(USR.usr_full_name)) AS usr_full_name,
          (SELECT err_error_message FROM Errors WHERE err_pmm_id = PMM.pmm_id) AS err_error_message,
          (SELECT COUNT(pmm_id) FROM Package_Movement_Master WHERE pmm_parent_id = PMM.pmm_parent_id) AS gonderilen_parca_adedi,
          (SELECT COUNT(pmm_id) FROM Package_Movement_Master WHERE pmm_parent_id = PMM.pmm_parent_id AND pmm_declaration_id IS NOT NULL) AS cevaplanan_parca_adedi,
          (SELECT COUNT(pmd_id) FROM Package_Movement_Detail WHERE pmd_pmm_id = PMM.pmm_id) AS toplam_gonderilen_ambalaj_adedi,
          (SELECT COUNT(pmd_id) FROM Package_Movement_Detail WHERE pmd_pmm_id = PMM.pmm_id AND pmd_response_code = '00000') AS kabul_edilen_ambalaj_adedi,
          (SELECT COUNT(pmd_id) FROM Package_Movement_Detail WHERE pmd_pmm_id = PMM.pmm_id AND pmd_response_code <> '00000') AS kabul_edilmeyen_ambalaj_adedi,
          (SELECT COUNT(pmd_id) FROM Package_Movement_Detail WHERE pmd_pmm_id = PMM.pmm_id AND pmd_response_code = '10007') AS daha_once_kaydedilmis_ambalaj_adedi
   FROM Package_Movement_Master PMM
   INNER JOIN Cancelled_Sales_Master CSM ON (CSM.csm_document_number = PMM.pmm_order_id)   
   INNER JOIN Account_Master AMR ON (AMR.amr_account_code = CSM.csm_account_code)
   LEFT JOIN TESTTCP.SECURITY.dbo.Users USR ON (USR.usr_id = PMM.pmm_usr_id)
   WHERE PMM.pmm_datetime BETWEEN ISNULL(@begin_date, PMM.pmm_datetime) AND ISNULL(@end_date, PMM.pmm_datetime)
     AND (ISNULL(@item_name, '') = '' OR dbo.TRK(AMR.amr_account_name) LIKE @item_name + '%' ESCAPE '\' )   
     AND (ISNULL(@order_id, '') = '' OR CSM.csm_document_number LIKE '\' + @order_id + '%' ESCAPE '\' )     
     AND (@parent_id IS NULL OR PMM.pmm_parent_id = @parent_id) 
     AND (@parent_ids IS NULL OR PMM.pmm_parent_id IN (SELECT parent_id FROM @tparent_ids)) 
     AND (@types IS NULL OR PMM.pmm_type IN (SELECT [type] FROM @ttypes))
     AND (@is_scheduled IS NULL OR ISNULL(PMM.pmm_is_scheduled, 0) = @is_scheduled)          
   ORDER BY pmm_datetime, pmm_order_id
GO

/****** Object: Stored Procedure [dbo].[Package_Movement_Master_Insert]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_Movement_Master_Insert]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Package_Movement_Master_Insert]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_Movement_Master_Insert]
   @pmm_key            VARCHAR(20),
   @pmm_order_id       VARCHAR(20),
   @pmm_type           CHAR(1),   
   @pmm_parent_id      INT = NULL,
   @pmm_declaration_id VARCHAR(20) = NULL,
   @pmm_usr_id         INT,
   @pmm_environment    CHAR(1),
   @pmm_is_scheduled   BIT = 0
AS
   INSERT INTO Package_Movement_Master
          (pmm_key,
           pmm_order_id,
           pmm_type,
           pmm_parent_id,
           pmm_declaration_id,
           pmm_usr_id,
           pmm_environment,
           pmm_is_scheduled)
   VALUES (@pmm_key,
           @pmm_order_id,
           @pmm_type,
           @pmm_parent_id,
           @pmm_declaration_id,
           @pmm_usr_id,
           @pmm_environment,
           @pmm_is_scheduled)
           
   IF @@ROWCOUNT = 0 OR @@ERROR <> 0
   BEGIN
      RAISERROR('Hareket başlık kaydı eklenemedi!', 16, 1)
      RETURN -1
   END  
   
   IF @pmm_parent_id IS NULL
   BEGIN
      UPDATE Package_Movement_Master
      SET pmm_parent_id = SCOPE_IDENTITY()
      WHERE pmm_id = SCOPE_IDENTITY()
   
      IF @@ROWCOUNT = 0 OR @@ERROR <> 0
      BEGIN
         RAISERROR('Hareket başlık kaydı eklenemedi!', 16, 1)
         RETURN -1
      END     
   END
      
   RETURN SCOPE_IDENTITY()
GO

/****** Object: Stored Procedure [dbo].[Package_Movement_Master_Update]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_Movement_Master_Update]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Package_Movement_Master_Update]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_Movement_Master_Update]
   @pmm_id                INT,
   @pmm_declaration_id    VARCHAR(20) = NULL,
   @pmm_sending_file_name VARCHAR(100)= NULL,
   @pmm_coming_file_name  VARCHAR(100) = NULL
AS
   UPDATE Package_Movement_Master
   SET pmm_declaration_id = ISNULL(@pmm_declaration_id, pmm_declaration_id),
       pmm_coming_file_name = ISNULL(@pmm_coming_file_name, pmm_coming_file_name),
       pmm_sending_file_name = ISNULL(@pmm_sending_file_name, pmm_sending_file_name)
   WHERE pmm_id = @pmm_id

           
   IF @@ROWCOUNT = 0 OR @@ERROR <> 0
   BEGIN
      RAISERROR('Hareket başlık kaydı güncellenemedi!', 16, 1)
      RETURN -1
   END  

   DELETE Scheduled_Declaration
   FROM Package_Movement_Master PMM
   WHERE sch_order_id = PMM.pmm_order_id
     AND sch_type = PMM.pmm_type
     AND sch_status = 'W'
     AND PMM.pmm_id = @pmm_id
GO

/****** Object: Stored Procedure [dbo].[Package_Search]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_Search]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Package_Search]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_Search]
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
   WHERE PCK.pck_code LIKE @pck_code + '%' OR PCK.pck_sscc = @pck_sscc
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

/****** Object: Stored Procedure [dbo].[Production_Decalaration_Report]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Production_Decalaration_Report]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Production_Decalaration_Report]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Production_Decalaration_Report] --'21926'
   @order_id VARCHAR(20)
AS
   SELECT *,
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id = ORD.ord_order_id
             AND pck_status = 'W'
             AND pck_status_id = 10) AS unsent_quantity,
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id = ORD.ord_order_id
             AND pck_status <> 'W') AS sent_quantity,             
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id = ORD.ord_order_id
             AND pck_status_id = 10) AS approval_quantity,             
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id = ORD.ord_order_id
             AND pck_status_id <> 10) AS disapproval_quantity,                          
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id = ORD.ord_order_id) AS total_package_quantity
   FROM (SELECT ORD.ord_order_id,
                ORD.ord_batch_no,
                MMR.mmr_item_no,
                dbo.TRK(MMR.mmr_item_name) AS mmr_item_name,
                MMR.mmr_gtin,
                ORD.ord_target_quantity,
                CONVERT(VARCHAR(10), ORD.ord_expiry_date, 103) AS ord_expiry_date,
                CONVERT(VARCHAR(10), ORD.ord_order_start_date, 120) AS start_date,
                CONVERT(VARCHAR(10), ORD.ord_expiry_date, 120) AS expiry_date,
                PMM.pmm_datetime,
                COUNT(CASE PMD.pmd_response_code
                        WHEN '10007' THEN PMD.pmd_pck_id
                        WHEN '00000' THEN PMD.pmd_pck_id
                        ELSE NULL
                      END) AS declaration_count,
                dbo.TRK(dbo.Fn_Sifre_Coz(USR.usr_full_name)) AS usr_full_name
         FROM Order_List ORD
         INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id)  
         INNER JOIN Package_Movement_Master PMM ON (PMM.pmm_order_id = ORD.ord_order_id)
         INNER JOIN Package_Movement_Detail PMD ON (PMD.pmd_pmm_id = PMM.pmm_id)  
         INNER JOIN TESTTCP.SECURITY.dbo.Users USR ON (USR.usr_id = PMM.pmm_usr_id)
         WHERE ORD.ord_order_id = @order_id
           AND PMM.pmm_declaration_id IS NOT NULL
           AND PMM.pmm_type = 'P'
         GROUP BY ORD.ord_order_id,
                  ORD.ord_batch_no,
                  MMR.mmr_item_no,
                  MMR.mmr_item_name,
                  MMR.mmr_gtin,
                  MMR.mmr_registered_to,
                  ORD.ord_target_quantity,
                  CONVERT(VARCHAR(10), ORD.ord_expiry_date, 103),
                  CONVERT(VARCHAR(10), ORD.ord_order_start_date, 120),
                  CONVERT(VARCHAR(10), ORD.ord_expiry_date, 120),
                  PMM.pmm_datetime,
                  dbo.TRK(dbo.Fn_Sifre_Coz(USR.usr_full_name))) ORD
   ORDER BY pmm_datetime
GO

/****** Object: Stored Procedure [dbo].[Production_Declaration_Control]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Production_Declaration_Control]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Production_Declaration_Control]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Production_Declaration_Control]
   @order_id VARCHAR(20)
AS
   SELECT COUNT(pck_code) AS count_of_code
   FROM Package_List WITH (NOLOCK)
   WHERE pck_status NOT IN ('W', 'D')
     AND pck_status_id = 10
     AND pck_order_id = @order_id
GO

/****** Object: Stored Procedure [dbo].[Production_Detail]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Production_Detail]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Production_Detail]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Production_Detail]
   @mmr_item_no VARCHAR(35),
   @batch_no    VARCHAR(20)
/*
{******************************************************************************}
{  Amaç         : Malzeme ve seri bazında detaylarını listelemek               }
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
     
   SELECT SUM(ORD.ord_target_quantity) AS ord_target_quantity,
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id IN (SELECT ord_order_id FROM @Order_List)
             AND pck_status = 'W'
             AND pck_status_id = 10) AS unsent_quantity,
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id IN (SELECT ord_order_id FROM @Order_List)
             AND pck_status <> 'W') AS sent_quantity,             
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id IN (SELECT ord_order_id FROM @Order_List)
             AND pck_status_id = 10) AS approval_quantity,             
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id IN (SELECT ord_order_id FROM @Order_List)
             AND pck_status_id <> 10) AS disapproval_quantity,                          
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id IN (SELECT ord_order_id FROM @Order_List)) AS total_package_quantity,
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id IN (SELECT ord_order_id FROM @Order_List)
             AND pck_status = 'D') AS made_of_deactivation_quantity,        
          (SELECT COUNT(pck_code)
           FROM Package_List
           WHERE pck_order_id IN (SELECT ord_order_id FROM @Order_List)
             AND pck_status_id = '98'
             AND pck_status = 'P') AS deactivation_quantity,
          ISNULL((SELECT TOP 1 1
                  FROM Package_List 
                  WHERE pck_order_id IN (SELECT ord_order_id FROM @Order_List)
                    AND pck_sscc IS NOT NULL), 0) AS sscc_found             
   FROM Order_List ORD
   WHERE ORD.ord_order_id IN (SELECT ord_order_id FROM @Order_List)
GO

/****** Object: Stored Procedure [dbo].[Report_Change_Ministry_Of_Health]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Report_Change_Ministry_Of_Health]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Report_Change_Ministry_Of_Health]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE  [dbo].[Report_Change_Ministry_Of_Health]
   @year          SMALLINT
AS
/*
{******************************************************************************}
{  Amaç         : Bakanlık bildirim raporu                                     }
{  Param. Gelen :                                                              }
{  Açıklama     :                                                              }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     30.12.2011  AY       Başlandı.                                    }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
   SELECT CHI.chi_id,
          ISNULL(CHI.chi_real_number, CHI.chi_temporary_number) AS chi_number,
          CONVERT(VARCHAR(10), CDA.cda_date_of_application_to_the_ministry_of_health, 103) AS date_of_application_to_the_ministry_of_health,
          CASE CDA.cda_wait_for_approval_of_the_ministry_of_health
            WHEN 0 THEN N'Gerekli değil'
            WHEN 1 THEN N'Gerekli'
          END AS wait_for_approval_of_the_ministry_of_health,
          CASE CLC.clc_ministry_of_health_approved
            WHEN 0 THEN N'Bakanlık onayı beklenmemektedir'
            WHEN 1 THEN N'Bakanlık onayı gelmiştir'
            WHEN 2 THEN N'14 günlük bekleme süresi dolmuştur'
            WHEN 3 THEN N'30 günlük bekleme süresi dolmuştur'
          END AS ministry_of_health_approved,
          SUBSTRING((SELECT DISTINCT ', ' + CONVERT(VARCHAR(10), CMH.cmh_date_of_ministry_of_health_approval, 103)
                     FROM Change_Ministry_of_Health_Approvals CMH                 
                     WHERE cmh_chi_id = CHI.chi_id
                     FOR XML PATH(N''), elements), 3, 4000) AS dates_of_ministry_of_health_approval
   FROM Change_Information CHI
   INNER JOIN Change_Department_Assesment CDA ON (CDA.cda_chi_id = CHI.chi_id)
   LEFT JOIN Change_Of_The_License_Is_Completed CLC ON (CLC.clc_chi_id = CHI.chi_id)
   WHERE CDA.cda_notified_the_ministry_of_health = 1
     AND (@year IS NULL OR YEAR(CHI.chi_temporary_date) = @year)
   ORDER BY CHI.chi_id
GO

/****** Object: Stored Procedure [dbo].[Scheduled_Declaration_Browse]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Scheduled_Declaration_Browse]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Scheduled_Declaration_Browse]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Scheduled_Declaration_Browse]
AS 
/*
{*****************************************************************************}
{  Amaç         : Zamanlanmış ancak bildirim yapılmamış kayıtları listelemek  }
{  Param. Gelen :                                                             }
{                                                                             }
{  Açıklama     :                                                             }
{                                                                             }
{  Düzenleme Tarihçesi:                                                       }
{  Versiyon  Tarih       Kişi     Açıklama                                    }
{    1.1     27/12/2011  AY       Başlanıldı                                  }
{                                                                             }
{  Kısaltmalar:                                                               }
{  AY : Ali YAZICI                                                            }
{*****************************************************************************} 
*/
   SELECT *
   FROM Scheduled_Declaration
   WHERE sch_status = 'W'
GO

/****** Object: Stored Procedure [dbo].[Scheduled_Declaration_Browse_For_Report]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Scheduled_Declaration_Browse_For_Report]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Scheduled_Declaration_Browse_For_Report]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Scheduled_Declaration_Browse_For_Report]
   @begin_date    DATETIME = NULL,
   @end_date      DATETIME = NULL,
   @item_name     VARCHAR(50) = NULL,
   @order_id      VARCHAR(20) = NULL,
   @rowcount      INT = NULL,   
   @types         VARCHAR(100) = NULL
/*
{******************************************************************************}
{  Amaç         : Zamanlanmış bildirimleri listesini oluşturmak                }
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
   DECLARE @I INT
   DECLARE @S VARCHAR(20)

   SET NOCOUNT ON 
   
	DECLARE @ttypes TABLE ([type] CHAR(1))
   SET @I = 0
   SET @S = ''

   WHILE LEN(@types) > @I
   BEGIN
      SET @I = @I + 1
      IF (SUBSTRING(@types, @I, 1) = ',')
      BEGIN
         INSERT INTO @ttypes
         SELECT @S
			SET @S=''
         CONTINUE
      END
      SET  @S = @S + SUBSTRING(@types, @I, 1)
   END
   
   SET NOCOUNT OFF
   
   SET @rowcount = ISNULL(@rowcount, 100)   
   SET ROWCOUNT @rowcount
   
   SELECT @begin_date = CONVERT(DATETIME,(CONVERT(VARCHAR(10), @begin_date, 120)) + ' 00:00:01',120),
          @end_date = CONVERT(DATETIME,(CONVERT(VARCHAR(10), @end_date, 120)) + ' 23:59:59',120)
          
   SELECT SCH.sch_order_id,
          SCH.sch_type,
          CASE SCH.sch_type
            WHEN 'P' THEN N'Üretim'
            WHEN 'D' THEN N'Deaktivasyon'
            WHEN 'S' THEN N'Satış'
            WHEN 'E' THEN N'İhracat'
            WHEN 'T' THEN N'Satış İptal'
            WHEN 'C' THEN N'PTS'
          END AS type,
          SCH.sch_created_time,
          dbo.TRK(dbo.Fn_Sifre_Coz(USR.usr_full_name)) AS usr_full_name,
          SCH.sch_scheduled_time,
          SCH.sch_declaration_time,
          ORD.ord_batch_no,
          ORD.ord_expiry_date,
          MMR.mmr_item_no,
          dbo.TRK(MMR.mmr_item_name) AS mmr_item_name,
          MMR.mmr_item_no + ' / ' + dbo.TRK(MMR.mmr_item_name) AS item_desc,
          AMR.amr_account_code,
          AMR.amr_account_name,
          AMR.amr_account_code + ' / ' + AMR.amr_account_name AS account_desc,
          SOR.sor_invoice_number,
          SOR.sor_invoice_date
   FROM Scheduled_Declaration SCH
   LEFT JOIN TESTTCP.SECURITY.dbo.Users USR ON (USR.usr_id = SCH.sch_created_usr_id)
   LEFT JOIN Order_List ORD ON (ORD.ord_order_id = SCH.sch_order_id AND SCH.sch_type IN ('P', 'D'))   
   LEFT JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id)    
   LEFT JOIN Shipping_Order_List SOR ON (SOR.sor_order_number = SCH.sch_order_id AND SCH.sch_type IN ('S', 'C', 'T'))
   LEFT JOIN Account_Master AMR ON (AMR.amr_account_code = SOR.sor_account_code)   
   WHERE SCH.sch_created_time BETWEEN ISNULL(@begin_date, SCH.sch_created_time) AND ISNULL(@end_date, SCH.sch_created_time)   
     AND (ISNULL(@item_name, '') = '' OR MMR.mmr_item_name LIKE '\' + @item_name + '%' ESCAPE '\' OR AMR.amr_account_name LIKE '\' + @item_name + '%' ESCAPE '\')
     AND (ISNULL(@order_id, '') = '' OR SCH.sch_order_id LIKE '\' + @order_id + '%' ESCAPE '\' )     
     AND (@types IS NULL OR SCH.sch_type IN (SELECT [type] FROM @ttypes))
GO

/****** Object: Stored Procedure [dbo].[Scheduled_Declaration_Delete]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Scheduled_Declaration_Delete]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Scheduled_Declaration_Delete]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Scheduled_Declaration_Delete]
   @sch_order_id        VARCHAR(20), 
   @sch_type            CHAR(1)
AS 
/*
{*****************************************************************************}
{  Amaç         : Bildirim zamanlamasını silmek.                              }
{  Param. Gelen : sch_order_id (Üretim ya da Satış numarassı)                 }
{                 sch_type (Tipi (P: Üretim, S: Satış, T: PTS, E: Ihracat))   }
{                                                                             }
{  Açıklama     :                                                             }
{                                                                             }
{  Düzenleme Tarihçesi:                                                       }
{  Versiyon  Tarih       Kişi     Açıklama                                    }
{    1.1     03/01/2012  AY       Başlanıldı                                  }
{                                                                             }
{  Kısaltmalar:                                                               }
{  AY : Ali YAZICI                                                            }
{*****************************************************************************} 
*/
   IF EXISTS(SELECT 1
             FROM Scheduled_Declaration
             WHERE sch_order_id = @sch_order_id
               AND sch_type = @sch_type
               AND sch_status = 'F')
   BEGIN
      RAISERROR(N'%s numaralı iş emrine ait bildirim tamamlanmıştır!', 16, 1, @sch_order_id)
      RETURN
   END
   
   BEGIN TRY
      DELETE  Scheduled_Declaration
      WHERE sch_order_id = @sch_order_id
        AND sch_type = @sch_type
   END TRY          
   BEGIN CATCH
      DECLARE @ERROR_MESSAGE NVARCHAR(2048)
      SET @ERROR_MESSAGE = ERROR_MESSAGE()
      RAISERROR(N'Kayıt silinemedi. Hata = %s', 16, 1, @ERROR_MESSAGE)      
   END CATCH
GO

/****** Object: Stored Procedure [dbo].[Scheduled_Declaration_Insert]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Scheduled_Declaration_Insert]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Scheduled_Declaration_Insert]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Scheduled_Declaration_Insert]
   @sch_order_id        VARCHAR(20), 
   @sch_type            CHAR(1), 
   @sch_scheduled_time  DATETIME,
   @usr_id              INT
AS 
/*
{*****************************************************************************}
{  Amaç         : Bildirim zamanlaması eklemek.                               }
{  Param. Gelen : sch_order_id (Üretim ya da Satış numarassı)                 }
{                 sch_type (Tipi (P: Üretim, S: Satış, C: PTS, E: Ihracat))   }
{               	sch_scheduled_time (Bildirim zamanı)                        }
{               	usr_id (Kaydı Ekleyen Kullanıcı Id)                         }
{                                                                             }
{  Açıklama     :                                                             }
{                                                                             }
{  Düzenleme Tarihçesi:                                                       }
{  Versiyon  Tarih       Kişi     Açıklama                                    }
{    1.1     27/12/2011  AY       Başlanıldı                                  }
{                                                                             }
{  Kısaltmalar:                                                               }
{  AY : Ali YAZICI                                                            }
{*****************************************************************************} 
*/
   IF EXISTS(SELECT 1
             FROM Scheduled_Declaration
             WHERE sch_order_id = @sch_order_id
               AND sch_type = @sch_type
               AND sch_status = 'F')
   BEGIN
      --RAISERROR(N'%s numaralı iş emrine ait bildirim tamamlandığı için bu iş emrine zamanlama tanımlayamazsınız!', 16, 1, @sch_order_id)
      RETURN
   END
   
   BEGIN TRY
      IF EXISTS(SELECT 1
                FROM Scheduled_Declaration
                WHERE sch_order_id = @sch_order_id
                  AND sch_type = @sch_type)
      BEGIN
         UPDATE Scheduled_Declaration
         SET sch_scheduled_time = @sch_scheduled_time,
             sch_created_time = GETDATE(),
             sch_created_usr_id = @usr_id
         WHERE sch_order_id = @sch_order_id
           AND sch_type = @sch_type 
      END
      ELSE
      BEGIN
         INSERT INTO Scheduled_Declaration
                (sch_order_id, 
                 sch_type, 
                 sch_scheduled_time,
                 sch_created_usr_id)
         VALUES (@sch_order_id, 
                 @sch_type, 
                 @sch_scheduled_time,
                 @usr_id)           
      END
   END TRY          
   BEGIN CATCH
      DECLARE @ERROR_MESSAGE NVARCHAR(2048)
      SET @ERROR_MESSAGE = ERROR_MESSAGE()
      RAISERROR(N'Kayıt eklenemedi. Hata = %s', 16, 1, @ERROR_MESSAGE)      
   END CATCH
GO

/****** Object: Stored Procedure [dbo].[Shipping_Order_Browse]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shipping_Order_Browse]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Shipping_Order_Browse]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Shipping_Order_Browse]
   @order_number   NVARCHAR(20),
   @invoice_number VARCHAR(10) = NULL
AS
/*
{******************************************************************************}
{  Amaç         : Sevkiyat iş emrinin bilgilerinin listelenmesi.               }
{																										 }
{  Param. Gelen : order_number (İş emri numarası)                              }
{                 invoice_number (Fatura numarası)                             }
{																										 }
{  Açıklama     :                                                              }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     09/12/2011  AY		 Başladı.												 }
{    1.1     10/01/2012  AY       invoice_number parametresi eklendi.          }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
   SELECT SOR.sor_id,
          SOR.sor_order_number,
          CONVERT(VARCHAR(10), SOR.sor_completion_date, 120) AS sor_completion_date,
          AMR.amr_gln_number,
          AMR.amr_branch_gln_number,
          COM.com_gln_number,
          AMR.amr_account_code,
          AMR.amr_account_name,
          AMR.amr_account_code + ' / ' + dbo.TRK(AMR.amr_account_name) AS account_name,
          SOR.sor_invoice_number,
          SOR.sor_invoice_date,
          SOR.sor_pts_transfered_date,
          SOR.sor_pts_transfer_id,
          (SELECT TOP 1 PMM.pmm_datetime
           FROM Package_Movement_Master PMM
           WHERE PMM.pmm_order_id = SOR.sor_order_number
             AND PMM.pmm_type = 'S'
             AND PMM.pmm_declaration_id IS NOT NULL
           ORDER BY PMM.pmm_id DESC) AS sales_declaration_date,
          (SELECT TOP 1 SCH.sch_scheduled_time
           FROM Scheduled_Declaration SCH
           WHERE SCH.sch_order_id = SOR.sor_order_number
             AND SCH.sch_type = 'S') AS sales_scheduled_time,
          (SELECT TOP 1 SCH.sch_scheduled_time
           FROM Scheduled_Declaration SCH
           WHERE SCH.sch_order_id = SOR.sor_order_number
             AND SCH.sch_type = 'C') AS pts_scheduled_time,
          ISNULL((SELECT COUNT(DISTINCT package_sscc)
                  FROM dbo.fn_get_shipping_packages_with_aggregations(SOR.sor_order_number)), 0) AS case_count_of_shipping,                
          ISNULL((SELECT COUNT(package_id)
                  FROM dbo.fn_get_shipping_packages_with_aggregations(SOR.sor_order_number)), 0) AS package_count_of_shipping,
          ISNULL((SELECT COUNT(package_id)
                  FROM dbo.fn_get_shipping_packages_with_aggregations(SOR.sor_order_number) AGG
                  INNER JOIN Package_List PCK ON (PCK.pck_id = AGG.package_id)
                  WHERE PCK.pck_status = 'S'), 0) AS shipped_package_count
       
   FROM Shipping_Order_List SOR 
   INNER JOIN Account_Master AMR ON (AMR.amr_account_code = SOR.sor_account_code)
   INNER JOIN Companies COM ON (COM.com_id = SOR.sor_com_id)
   WHERE SOR.sor_order_number = @order_number
      OR SOR.sor_invoice_number = @invoice_number
GO

/****** Object: Stored Procedure [dbo].[Shipping_Order_Detail_Packages_Browse]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shipping_Order_Detail_Packages_Browse]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Shipping_Order_Detail_Packages_Browse]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Shipping_Order_Detail_Packages_Browse] 
   @order_number NVARCHAR(20)
AS
/*
{******************************************************************************}
{  Amaç         : Sevkiyat iş emrinin detaylarının listelenmesi.               }
{																										 }
{  Param. Gelen : order_number (İş emri numarası)                              }
{																										 }
{  Açıklama     :                                                              }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     09/12/2011  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
   SELECT AGG.*,
          MMR.mmr_item_no,
          MMR.mmr_item_name,
          MMR.mmr_item_no + ' / ' + dbo.TRK(MMR.mmr_item_name) AS item_name,
          CAST(AGG.expiry_date AS SMALLDATETIME) AS expiry_date_
   FROM dbo.fn_get_shipping_packages_with_aggregations(@order_number) AGG
   INNER JOIN Material_Master MMR ON (MMR.mmr_gtin = AGG.gtin)
   ORDER BY parent_sscc,
            package_sscc,
            gtin,
            batch_no
GO

/****** Object: Stored Procedure [dbo].[Shipping_Order_Detail_SSCC_Browse]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shipping_Order_Detail_SSCC_Browse]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Shipping_Order_Detail_SSCC_Browse]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Shipping_Order_Detail_SSCC_Browse] 
   @order_number NVARCHAR(20)
AS
/*
{******************************************************************************}
{  Amaç         : Sevkiyat iş emrinin detaylarının SSCC'lerinin listelenmesi   }
{																										 }
{  Param. Gelen : order_number (İş emri numarası)                              }
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
   SELECT DISTINCT
          parent_sscc,
          package_sscc
   FROM dbo.fn_get_shipping_packages_with_aggregations(@order_number)
   ORDER BY parent_sscc,
            package_sscc
GO

/****** Object: Stored Procedure [dbo].[Shipping_Order_Details_Browse]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shipping_Order_Details_Browse]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Shipping_Order_Details_Browse]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Shipping_Order_Details_Browse] 
   @order_number NVARCHAR(20)
AS
/*
{******************************************************************************}
{  Amaç         : Sevkiyat iş emrinin detaylarının listelenmesi.               }
{																										 }
{  Param. Gelen : order_number (İş emri numarası)                              }
{																										 }
{  Açıklama     :                                                              }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     09/12/2011  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
   SELECT * 
   FROM dbo.fn_get_shipping_packages_with_aggregations(@order_number)
   ORDER BY parent_sscc,
            package_sscc,
            gtin,
            batch_no
GO

/****** Object: Stored Procedure [dbo].[Shipping_Order_List_Browse_For_Declaration]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shipping_Order_List_Browse_For_Declaration]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Shipping_Order_List_Browse_For_Declaration]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Shipping_Order_List_Browse_For_Declaration]
/*
{******************************************************************************}
{  Amaç         : Satış bildirimi yapılabilir sevkiyat iş emirlerinin          }
{                 listelenmesi.                                                }
{  Param. Gelen :                                                              }
{																										 }
{  Açıklama     :                                                              }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     14/12/2011  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
AS
   SELECT *,
          (SELECT TOP 1 SCH.sch_scheduled_time
           FROM Scheduled_Declaration SCH
           WHERE SCH.sch_order_id = T.sor_order_number
             AND SCH.sch_type = 'S') AS sales_scheduled_time,
          (SELECT TOP 1 SCH.sch_scheduled_time
           FROM Scheduled_Declaration SCH
           WHERE SCH.sch_order_id = T.sor_order_number
             AND SCH.sch_type = 'C') AS pts_scheduled_time,             
          CAST(CASE package_count_of_shipping - shipped_package_count 
                  WHEN 0 THEN 0
                  ELSE 1
               END AS BIT) AS sales_dec_should_be_done,
          CAST(CASE 
                  WHEN sor_pts_transfer_id IS NULL AND package_count_of_shipping > 0 THEN 1
                  ELSE 0
               END AS BIT) AS pts_should_be_done,
          CAST(0 AS BIT) AS checked
   FROM (SELECT SOR.sor_order_number,
                dbo.TRK(AMR.amr_account_name) AS amr_account_name,
                SOR.sor_completion_date,
                SOR.sor_pts_transfer_id,
                ISNULL((SELECT COUNT(DISTINCT package_sscc)
                        FROM dbo.fn_get_shipping_packages_with_aggregations(SOR.sor_order_number)), 0) AS case_count_of_shipping,                
                ISNULL((SELECT COUNT(package_id)
                        FROM dbo.fn_get_shipping_packages_with_aggregations(SOR.sor_order_number)), 0) AS package_count_of_shipping,
                ISNULL((SELECT COUNT(package_id)
                        FROM dbo.fn_get_shipping_packages_with_aggregations(SOR.sor_order_number) AGG
                        INNER JOIN Package_List PCK WITH (NOLOCK) ON (PCK.pck_id = AGG.package_id)
                        WHERE PCK.pck_status = 'S'), 0) AS shipped_package_count
         FROM Shipping_Order_List SOR
         INNER JOIN Account_Master AMR ON (AMR.amr_account_code = SOR.sor_account_code)
         WHERE SOR.sor_was_declaration < 2
            OR SOR.sor_pts_transfer_id IS NULL) T
   WHERE T.package_count_of_shipping > 0
   ORDER BY sor_order_number
GO

/****** Object: Stored Procedure [dbo].[Shipping_Order_List_Browse_For_PTS]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shipping_Order_List_Browse_For_PTS]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Shipping_Order_List_Browse_For_PTS]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Shipping_Order_List_Browse_For_PTS]
/*
{******************************************************************************}
{  Amaç         : PTS bildirimi yapılabilir sevkiyat iş emirlerinin            }
{                 listelenmesi.                                                }
{  Param. Gelen :                                                              }
{																										 }
{  Açıklama     :                                                              }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     09/12/2011  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
AS
   SELECT SOR.sor_order_number,
          dbo.TRK(AMR.amr_account_name) AS amr_account_name,
          SOR.sor_completion_date,
          (SELECT TOP 1 SCH.sch_scheduled_time
           FROM Scheduled_Declaration SCH
           WHERE SCH.sch_order_id = SOR.sor_order_number
             AND SCH.sch_type = 'C') AS scheduled_time,
          CAST(0 AS BIT) AS checked
   FROM Shipping_Order_List SOR
   INNER JOIN Account_Master AMR ON (AMR.amr_account_code = SOR.sor_account_code)
   WHERE sor_pts_transfer_id IS NULL
   ORDER BY SOR.sor_order_number
GO

/****** Object: Stored Procedure [dbo].[Shipping_Order_Update_Transfer_Id]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shipping_Order_Update_Transfer_Id]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Shipping_Order_Update_Transfer_Id]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Shipping_Order_Update_Transfer_Id] 
   @order_number    NVARCHAR(20),
   @pts_transfer_id BIGINT
AS
/*
{******************************************************************************}
{  Amaç         : Sevkiyat iş emrinin pts bildirimi yapılması sonrasında       }
{                 gelen transfer id bilgisinin kaydedilmesi.                   }
{  Param. Gelen : order_number (İş emri numarası)                              }
{                 pts_transfer_id (PTS Transfer Id)                            }
{																										 }
{  Açıklama     :                                                              }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     13/12/2011  AY		 Başladı.												 }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
   UPDATE Shipping_Order_List
   SET sor_pts_transfer_id = @pts_transfer_id,
       sor_pts_transfered_date = GETDATE()
   WHERE sor_order_number = @order_number
GO

/****** Object: Stored Procedure [dbo].[Shipping_Packages_Counts]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shipping_Packages_Counts]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Shipping_Packages_Counts]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Shipping_Packages_Counts]
   @order_numbers NVARCHAR(MAX)
/*
{******************************************************************************}
{  Amaç         : Sevkiyat iş emrinin miktar bazında detaylarının listelenmesi.}
{																										 }
{  Param. Gelen : order_numbers (İş emri numaraları)                           }
{																										 }
{  Açıklama     :                       													 }
{                                                                              }
{  Düzenleme Tarihçesi:                                                        }
{  Versiyon  Tarih       Kişi     Açıklama                                     }
{    1.0     15/02/2011  AY       Başlandı.                                    }
{                                                                              }
{  Kısaltmalar:                                                                }
{  AY : Ali YAZICI                                                             }
{******************************************************************************}
*/
AS
   SELECT * FROM ITS.dbo.fn_get_shipping_packages_count_by_groups(@order_numbers)
GO

/****** Object: Stored Procedure [dbo].[Sp_ShrinkLog]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_ShrinkLog]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Sp_ShrinkLog]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_ShrinkLog] 
        @LogF  varchar(200),   
	@NSize INT
AS
/*
 	DESC: 	attempt to shrink the log file to a specific size
		gets logical file name and attempt size

	use ED_IST_GALENOS_03
		
	exec sp_shrinkLog 'ED_GALENOS_LOG',2
*/

SET NOCOUNT ON
DECLARE @MaxMin 	INT, 
	@LogicalFileName sysname, 
	@origs 		INT
DECLARE @Cnt 		INT, 
	@StartTime 	DATETIME, 
	@Truncl 	VARCHAR(255)

SELECT @LogicalFileName = @LogF
SELECT @MaxMin = 2

SELECT 	@origs = size 
FROM 	sysfiles
WHERE 	name = @LogicalFileName

SELECT 	'Original Size OF ' + db_name() + ' LOG IS ' + 
	CONVERT(VARCHAR(30),@origs) + ' 8K pages or ' + 
	CONVERT(VARCHAR(30),(@origs*8/1024)) + 'MB'
FROM 	sysfiles
WHERE 	name = @LogicalFileName

CREATE TABLE DumpTrn  (DumCol char (8000) NOT null)

SELECT 	@StartTime = GETDATE(),
        @Truncl = 'BACKUP LOG ['+ db_name() + '] WITH TRUNCATE_ONLY'

DBCC SHRINKFILE (@LogicalFileName, @NSize)
EXEC (@Truncl)

WHILE 		@MaxMin > DATEDIFF (mi, @StartTime, GETDATE()) 
 	AND 	@origs = (SELECT size FROM sysfiles WHERE name = @LogicalFileName) 
 	AND 	(@origs * 8 /1024) > @NSize 
                 
BEGIN 

    set @Cnt = 0

    WHILE ((@Cnt < @origs / 16) AND (@Cnt < 50000))
    BEGIN -- UPDATE
        INSERT DumpTrn VALUES ('Fill Log') -- Because it IS a char field it inserts 8000 bytes.
        DELETE DumpTrn
        set  @Cnt = @Cnt + 1
    END-- UPDATE
    EXEC (@Truncl) -- See IF a trunc OF the log shrinks it.
END-- OUTER loop

SELECT 'Final Size OF ' + db_name() + ' LOG IS ' +
CONVERT(VARCHAR(30),size) + ' 8K pages OR ' + 
CONVERT(VARCHAR(30),(size*8/1024)) + 'MB'
 FROM sysfiles 
 WHERE name = @LogicalFileName

DROP TABLE DumpTrn

PRINT '*** Perform a FULL DATABASE BACKUP ***'

SET NOCOUNT OFF
GO

/****** Object: Stored Procedure [dbo].[TTS_Production_Order_Browse]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TTS_Production_Order_Browse]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[TTS_Production_Order_Browse]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TTS_Production_Order_Browse] 
   @order_id VARCHAR(20)
AS
   SELECT TB022_ORDER_ID AS order_id,
          (SELECT TB026_USC_REQUIRED
           FROM TTS.TTS.dbo.TB026_TT_ORDER_ML 
           WHERE TB026_ORDER_ID = TB022_ORDER_ID) AS created_usc_count,
          CAST(ISNULL((SELECT COUNT(pck_id)
                       FROM Package_List
                       WHERE pck_original_order_id = TB022_ORDER_ID
                         AND pck_status_id = 10), 0) AS VARCHAR) + ' (' + 
          CAST(ISNULL((SELECT COUNT(pck_id)
                       FROM Package_List
                       WHERE pck_original_order_id = TB022_ORDER_ID
                         AND pck_status_id <> 10), 0) AS VARCHAR) + ')' AS package_count,
          (SELECT TB026_USC_REQUIRED
           FROM TTS.TTS.dbo.TB026_TT_ORDER_ML 
           WHERE TB026_ORDER_ID = TB022_ORDER_ID) - ISNULL((SELECT COUNT(pck_id)
                                                            FROM Package_List
                                                            WHERE pck_original_order_id = TB022_ORDER_ID), 0) AS diff,
          (SELECT ors_order_status_description
           FROM Order_Status
           WHERE ors_order_status_id = TB022_ORDER_STATUS_ID) AS order_status
   FROM TTS.TTS.dbo.TB022_TTORDERS 
   WHERE TB022_ORDER_ID LIKE @order_id + '%'
GO

/****** Object: Stored Procedure [dbo].[TTS_Production_Order_Insert_To_AGE]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TTS_Production_Order_Insert_To_AGE]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[TTS_Production_Order_Insert_To_AGE]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TTS_Production_Order_Insert_To_AGE] --'32020'
   @order_id VARCHAR(20)
AS
   DECLARE @gtin        VARCHAR(14),
           @batch_no    VARCHAR(20),
           @expiry_date SMALLDATETIME,
           @quantity    INT,
           @date        DATETIME
           
   DECLARE @RETURN_VALUE INT,
           @ID           INT,
           @URUN_R_ID    INT
           
	SELECT @gtin = mmr_gtin,
	       @batch_no = TB022_PK_BATCH_NO, 
	       @expiry_date = CONVERT(SMALLDATETIME,(CONVERT(VARCHAR(10), TB022_EXPIRY_DATE, 103)), 103),
	       @quantity = (SELECT TB026_USC_REQUIRED
                       FROM TTS.TTS.dbo.TB026_TT_ORDER_ML 
                       WHERE TB026_ORDER_ID = TB022_ORDER_ID),
          @date = TB022_REAL_START_DATE
   FROM TTS.TTS.dbo.TB022_TTORDERS 
   INNER JOIN TTS.TTS.dbo.TB020_ITEM_MASTER ON (TB020_ITEM_ID = TB022_ITEM_ID)
   INNER JOIN Material_Master ON (mmr_gtin = TB020_GTIN) 
   WHERE TB022_ORDER_ID = @order_id
      
   EXEC @RETURN_VALUE = KAREKOD..SP_URETIMEMRI_OLUSTUR N'8699536000015',
                                                       @gtin,
                                                       @quantity,
                                                       @expiry_date,
                                                       @batch_no,
                                                       @date,
                                                       @order_id,
                                                       @ID OUTPUT
                                                                    
   IF @RETURN_VALUE < 0
   BEGIN
      RAISERROR('070102-DSI-0001 - Üretim emri oluşturulamadı! %d', 16, 1, @RETURN_VALUE)      
      RETURN
   END      
   
   SELECT @URUN_R_ID = URUN_R_ID 
   FROM KAREKOD..URETIMEMRI 
   WHERE ID = @ID
   
   IF @@ROWCOUNT = 0
   BEGIN
      RAISERROR('070102-DSI-0001 - Üretim emri oluşturulamadı!', 16, 1)      
      RETURN   
   END
   
   INSERT INTO KAREKOD..URUN_URETIM
         (URUN_R_ID ,
          URETIMEMRI_R_ID,
          URUN_URETIM_01,
          URUN_URETIM_21,
          URUN_URETIM_17,
          URUN_URETIM_10,
          URUN_URETIM_FIYAT,
          URUN_URETIM_IMAL_TARIHI,
          URUN_URETIM_GENDATE,
          URUN_URETIM_DAMAGE, 
          URUN_URETIM_SONRAYAZ)						                  
	SELECT @URUN_R_ID,
	       @ID,
	       @gtin,-- COLLATE Turkish_CI_AS,
	       TB027_USC,-- COLLATE Turkish_CI_AS,
	       CONVERT(VARCHAR(6), @expiry_date, 12),-- COLLATE Turkish_CI_AS,
	       @batch_no,-- COLLATE Turkish_CI_AS,
	       '0',
	       CONVERT(VARCHAR(6), @date, 12),-- COLLATE Turkish_CI_AS,
	       GETDATE(),
	       1,
	       1
	FROM TTS.TTS.dbo.TB027_USC_LIST
	WHERE TB027_ORDER_ID = @order_id
	  AND TB027_USC NOT IN (SELECT URUN_URETIM_21 COLLATE database_default FROM KAREKOD..URUN_URETIM)	
	
	IF @@ERROR <> 0
	BEGIN
	   RAISERROR('070102-DSI-0002 - Kodlar gönderilemedi!', 16, 1)
	   RETURN
	END
	
	EXEC KAREKOD..SP_URETIMEMRINI_KULLANIMA_AC @ID
	
	IF @@ERROR <> 0
	BEGIN
	   RAISERROR('070102-DSI-0003 - Kodlar kullanıma açılamadı!', 16, 1)
	   RETURN
	END
GO

/****** Object: Stored Procedure [dbo].[Undeclared_Detail_Report]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Undeclared_Detail_Report]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[Undeclared_Detail_Report]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Undeclared_Detail_Report] 
AS
   SELECT *
   FROM (SELECT ORD.ord_order_id,
                MMR.mmr_item_no,
                dbo.TRK(MMR.mmr_item_name) AS mmr_item_name,
                ORD.ord_batch_no,             
                ORD.ord_target_quantity,
                (SELECT COUNT(pck_code)
                 FROM Package_List
                 WHERE pck_order_id = ORD.ord_order_id
                   AND pck_status = 'W'
                   AND pck_status_id = 10) AS unsent_quantity
         FROM Order_List ORD
         INNER JOIN Material_Master MMR ON (MMR.mmr_id = ORD.ord_mmr_id) 
         INNER JOIN Line_List LIN ON (LIN.lin_id = ORD.ord_line_id)) T
   WHERE T.unsent_quantity > 0
   ORDER BY ord_order_id --DESC
GO

/****** Object: Stored Procedure [dbo].[User_Authority]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_Authority]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[User_Authority]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_Authority] 
	@usr_id        INT,
   @fun_page_name VARCHAR(70) = NULL
AS
/*
{*****************************************************************************}
{  Amaç         : Kullanıcı yetki kontrolü                                    }
{  Param. Gelen : usr_id(Kullanıcı id'si)                                     }
{                 fun_page_name (Fonksiyon Sayfa Adı)                         }
{                                                                             }
{  Açıklama     : Kullanıcının haklarını listeler.                            }
{                                                                             }
{                                                                             }
{  Düzenleme Tarihçesi:                                                       }
{  Versiyon  Tarih       Kişi     Açıklama                                    }
{    1.0     01/02/2010  AY       Başlanıldı                                  }
{                                                                             }
{  Kısaltmalar:                                                               }
{  AY : Ali YAZICI                                                            }
{*****************************************************************************} 
*/ 
   
   SELECT UR.usr_id, 
          F.fun_id, 
          F.fun_page_name,
          UR.rgh_read, 
          UR.rgh_insert, 
          UR.rgh_update, 
          UR.rgh_delete, 
          UR.rgh_export, 
          UR.rgh_print
   FROM User_Rights UR
   INNER JOIN Functions F ON (UR.fun_id = F.fun_id)
   WHERE UR.usr_id = @usr_id
     AND F.fun_page_name = ISNULL(@fun_page_name, F.fun_page_name)
GO

/****** Object: Stored Procedure [dbo].[User_Rights_Browse]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_Rights_Browse]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[User_Rights_Browse]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_Rights_Browse] --null, null
	@usr_id INT = NULL,
	@fun_id TINYINT = NULL
AS
/*
{*****************************************************************************}
{  Amaç         : Kullanıcı Yetkilerini Listelemek                            }
{  Param. Gelen : usr_id(Kullanıcı Id),                                    	}
{                 fun_id(Fonksiyon Id)                                       	}
{                                                                             }
{  Açıklama     :                                                             }                                      
{                                                                             }
{  Düzenleme Tarihçesi:                                                       }
{  Versiyon  Tarih       Kişi     Açıklama                                    }
{    1.0     01/02/2010  AY       Başlanıldı                                  }
{                                                                             }
{  Kısaltmalar:                                                               }
{  AY : Ali YAZICI                                                            }
{*****************************************************************************} 
*/
   SELECT  UR.usr_id, 
           UR.fun_id, 
           F.fun_description,
           dbo.TRK(dbo.Fn_Sifre_Coz(U.usr_full_name)) AS usr_full_name,
           UR.rgh_read,
           UR.rgh_insert,
           UR.rgh_update,
           UR.rgh_delete,
           UR.rgh_export,
           UR.rgh_print,
           rgh_read_text = CASE UR.rgh_read
										WHEN 0 THEN 'Hayır' 
										WHEN 1 THEN 'Evet' 
									END,
           rgh_insert_text = CASE UR.rgh_insert
										WHEN 0 THEN 'Hayır' 
										WHEN 1 THEN 'Evet' 
									END,
           rgh_update_text = CASE UR.rgh_update
										WHEN 0 THEN 'Hayır' 
										WHEN 1 THEN 'Evet' 
									END,
           rgh_delete_text = CASE UR.rgh_delete
										WHEN 0 THEN 'Hayır' 
										WHEN 1 THEN 'Evet' 
									END,
           rgh_export_text = CASE UR.rgh_export
										WHEN 0 THEN 'Hayır' 
										WHEN 1 THEN 'Evet' 
									END,			
           rgh_print_text = CASE UR.rgh_print
										WHEN 0 THEN 'Hayır' 
										WHEN 1 THEN 'Evet' 
									END															
   FROM User_Rights UR
   INNER JOIN Functions F ON(F.fun_id = UR.fun_id) 
   INNER JOIN TESTTCP.SECURITY.dbo.Users U ON (U.usr_id = UR.usr_id)
   WHERE UR.usr_id =  ISNULL(@usr_id, UR.usr_id) 
     AND UR.fun_id =  ISNULL(@fun_id, UR.fun_id)
GO

/****** Object: Stored Procedure [dbo].[User_Rights_Delete]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_Rights_Delete]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[User_Rights_Delete]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_Rights_Delete]
   @usr_id 		INT,
	@fun_id 	 	SMALLINT
AS 
/*
{*****************************************************************************}
{  Amaç         : Kullanıcı Yetki Tanımlama kayıtlarının silinmesi            }
{  Param. Gelen : usr_id(Kullanıcı Id),                                    	}
{                 fun_id(Fonksiyon Id)                                       	}
{                                                                             }
{  Açıklama     : Kullancı haklarının User_Rights tablosundan silinme işlemini} 
{                 yapar                                                       }                                      
{                                                                             }
{  Düzenleme Tarihçesi:                                                       }
{  Versiyon  Tarih       Kişi     Açıklama                                    }
{    1.0     01/02/2010  AY       Başlanıldı                                  }
{                                                                             }
{  Kısaltmalar:                                                               }
{  AY : Ali YAZICI                                                            }
{*****************************************************************************} 
*/
   DELETE User_Rights
   WHERE usr_id = @usr_id 
     AND fun_id = @fun_id

	IF @@ERROR != 0 OR @@ROWCOUNT = 0
	BEGIN
		RAISERROR('Kullanıcı yetki tanımları silinemedi !', 16, 1)
		RETURN 	
	END
	
   RETURN 99
GO

/****** Object: Stored Procedure [dbo].[User_Rights_Insert_Or_Update]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_Rights_Insert_Or_Update]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[User_Rights_Insert_Or_Update]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_Rights_Insert_Or_Update]
	@usr_id 		            INT,
	@fun_id 		            SMALLINT,
	@rgh_read 		         TINYINT,
	@rgh_insert 		      TINYINT,
	@rgh_update 		      TINYINT,
	@rgh_delete 		      TINYINT,
	@rgh_export 		      TINYINT,
	@rgh_print 		         TINYINT,
	@mdf_usr_id 		      INT
AS 
/*
{*****************************************************************************}
{  Amaç         : Kullanıcı Yetkilerinin Kaydı                                }
{  Param. Gelen : usr_id(Kullanıcı Id),                                       }
{                 fun_id(Fonksiyon Id)                                        }
{               	rgh_read(Okuma hakkı)                                       }
{               	rgh_insert(Ekleme hakkı)                                    }
{                 rgh_update(Güncelleme hakkı)                                }
{               	rgh_delete(Silme hakkı)                                     }
{               	rgh_export(Aktarma hakkı)                                   }
{               	rgh_print(Yazdırma hakkı)                                   }
{               	mdf_usr_id(Kaydı Giren Kullanıcı numarası)                  }
{                                                                             }
{  Açıklama     :                                                             }
{                                                                             }
{  Düzenleme Tarihçesi:                                                       }
{  Versiyon  Tarih       Kişi     Açıklama                                    }
{    1.1     01/02/2010  AY       Başlanıldı                                  }
{                                                                             }
{  Kısaltmalar:                                                               }
{  AY : Ali YAZICI                                                            }
{*****************************************************************************} 
*/
			
   IF EXISTS(SELECT 1 
             FROM User_Rights
             WHERE usr_id = @usr_id
               AND fun_id = @fun_id) 
   BEGIN
	   UPDATE User_Rights
 	   SET rgh_read   = @rgh_read,
			 rgh_insert	= @rgh_insert,
			 rgh_update	= @rgh_update,
			 rgh_delete	= @rgh_delete,
			 rgh_export	= @rgh_export,
			 rgh_print	= @rgh_print
	   WHERE usr_id = @usr_id
		  AND fun_id = @fun_id

      IF @@ERROR != 0 
      BEGIN
         RAISERROR('Kullanıcı yetki tanımları güncellenemedi!', 16, 1)
		   RETURN 	
	   END      
   END
   ELSE
   BEGIN   
	   INSERT INTO User_Rights 
 		       (usr_id,
 		        fun_id,
 		        rgh_read,
		        rgh_insert,
		        rgh_update,
		        rgh_delete,
		        rgh_export,
		        rgh_print,
		        mdf_usr_id)    
	   VALUES (@usr_id,
		        @fun_id,
		        @rgh_read,
		        @rgh_insert,
		        @rgh_update,
		        @rgh_delete,
		        @rgh_export,
		        @rgh_print,
		        @mdf_usr_id)

      IF @@ERROR != 0 
      BEGIN
         RAISERROR('Kullanıcıya yetki verilemedi !', 16, 1)
         RETURN 	
      END
   END
   
   RETURN 99
GO

/****** Object: Stored Procedure [dbo].[WMS_Production_Order_Browse]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WMS_Production_Order_Browse]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[WMS_Production_Order_Browse]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[WMS_Production_Order_Browse] 
AS
   SELECT POM.pom_id,
          POM.pom_production_start_date,
          MMR.mmr_id,
          MMR.mmr_item_no,
          dbo.TRK(CAST(MMR.mmr_sanovel_material_name AS NVARCHAR(50))) AS mmr_sanovel_material_name,
          POM.pom_supplier_batch_number,
          POM.pom_amount,
          MMR.mmr_recipe_measure_unit_id,
          dbo.fn_get_expiry_date(POM.pom_id) AS expiry_date,
          (SELECT TOP 1 MMM.mmm_barcode
           FROM TESTTCP.GENERAL.dbo.MMR_Manufacturer MMM
           WHERE MMM.mmm_mmr_id = MMR.mmr_id
             AND MMM.mmm_supplier_code IS NOT NULL
           ORDER BY MMM.mmm_barcode DESC) AS barcode,
          MMR.mmr_shelf_life           
   FROM TESTTCP.GENERAL.dbo.Production_Order_Master POM
   INNER JOIN TESTTCP.GENERAL.dbo.Material_Master MMR ON (MMR.mmr_id = POM.pom_mmr_id)
   INNER JOIN Material_Master MMRI ON (MMRI.mmr_item_no = MMR.mmr_item_no)
   LEFT JOIN TESTTCP.GENERAL.dbo.Products_Countries_Relations PCR ON (PCR.pcr_mmr_id = MMR.mmr_id)
   LEFT JOIN TESTTCP.GENERAL.dbo.Countries CNT ON (PCR.pcr_cnt_id = CNT.cnt_id)
   LEFT JOIN Order_List ORD ON (ORD.ord_order_id = CAST(POM.pom_id AS VARCHAR(20)))
   --LEFT JOIN TTS.TTS.dbo.TB022_TTORDERS ORD ON (ORD.TB022_ORDER_ID = CAST(POM.pom_id AS VARCHAR(20)))
   WHERE POM.pom_production_finished = 0
     AND POM.pom_cancellation_code = 0
     AND POM.pom_db_code = 4
     AND POM.pom_brn_code = 0
     AND POM.pom_production_type = 0
     AND MMR.mmr_category = 4
     AND ORD.ord_order_id IS NULL
     AND ISNULL(CNT.cnt_countries_code, 'TR') = 'TR'
   ORDER BY POM.pom_id
GO

/****** Object: Stored Procedure [dbo].[WMS_Production_Order_Insert_To_TTS]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WMS_Production_Order_Insert_To_TTS]') AND type IN ('P', 'RF', 'PC')))
BEGIN
	DROP PROCEDURE [dbo].[WMS_Production_Order_Insert_To_TTS]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[WMS_Production_Order_Insert_To_TTS]
   @order_id    VARCHAR(20),
   @batch_no    VARCHAR(20),
   @line_id     INT,
   @gtin_no     VARCHAR(14),
   @quantity    INT,
   @start_date  DATETIME,
   @expiry_date DATETIME
   
AS
   IF PATINDEX('%[_]%', @order_id) > 0
   BEGIN
      DECLARE @ORJ_ORDER_ID VARCHAR(20),
              @SEQUENCE     INT,
              @PRE_ORDER_ID VARCHAR(20)

      SET @PRE_ORDER_ID = @order_id
      
      WHILE 1 = 1
      BEGIN        
         SELECT @ORJ_ORDER_ID = SUBSTRING(@PRE_ORDER_ID, 1, PATINDEX('%[_]%', @PRE_ORDER_ID) - 1),
                @SEQUENCE = CAST(SUBSTRING(@PRE_ORDER_ID, PATINDEX('%[_]%', @PRE_ORDER_ID) + 1, LEN(@PRE_ORDER_ID) - PATINDEX('%[_]%', @PRE_ORDER_ID)) AS INT)
         
         IF @SEQUENCE = 1
            SET @PRE_ORDER_ID = @ORJ_ORDER_ID
         ELSE IF @SEQUENCE > 1
            SET @PRE_ORDER_ID = @ORJ_ORDER_ID + '_' + CAST(@SEQUENCE - 1 AS VARCHAR)      
            
         IF PATINDEX('%[_]%', @PRE_ORDER_ID) = 0 BREAK
         IF EXISTS(SELECT 1
                   FROM TTS.TTS.dbo.TB022_TTORDERS A 
                   WHERE A.TB022_ORDER_ID = @PRE_ORDER_ID) BREAK
      END
         
      IF EXISTS(SELECT 1
                FROM TTS.TTS.dbo.TB022_TTORDERS A 
                WHERE A.TB022_ORDER_ID = @PRE_ORDER_ID) AND
         NOT EXISTS(SELECT 1
                    FROM TTS.TTS.dbo.TB022_TTORDERS A 
                    WHERE A.TB022_ORDER_ID = @PRE_ORDER_ID 
                      AND A.TB022_ORDER_STATUS_ID IN (90, 50))
      BEGIN
         DECLARE @ERROR_MESSAGE NVARCHAR(400)
         SET @ERROR_MESSAGE = N'070101-DSI-0003 - Oluşturmak istediğiniz üretim emri numarasına ait daha önce açılan ancak kapatılmayan üretim emri mevcut.' + 
               CHAR(13) + CHAR(10) + N'Bu üretim emri oluşturulamaz!'
         RAISERROR(@ERROR_MESSAGE, 16, 1)
         RETURN
      END                       
   END

   SET XACT_ABORT ON

   DECLARE @ITEM_ID        INT,
           @UOM_TARGET_ID  INT,
           @SEQUENCE_ORDER INT,
           @RATE           FLOAT,
           @QUANTITY_2     INT
           
   SET @gtin_no = CASE LEN(@gtin_no)
                     WHEN 13 THEN '0' + @gtin_no
                     ELSE @gtin_no
                  END
                  
   SELECT @ITEM_ID = TB020_ITEM_ID,
          @UOM_TARGET_ID = TB020_ITEM_TYPE_ID
   FROM TTS.TTS.dbo.TB020_ITEM_MASTER
   WHERE TB020_GTIN = @gtin_no
                        
   IF @@ROWCOUNT = 0
   BEGIN
      RAISERROR('070101-DSI-0001 - TTS sunucusunda %s GTIN numarasına ait malzeme tanımlaması yapılmamış!', 16, 1, @gtin_no)
      RETURN
   END              
   
   SELECT @SEQUENCE_ORDER = ISNULL(MAX(A.TB022_SEQUENCE_ORDER), 0) + 1   
   FROM TTS.TTS.dbo.TB022_TTORDERS A 
   WHERE A.TB022_LINE_ID = @line_id 
     AND A.TB022_ORDER_STATUS_ID <> 90
     AND A.TB022_ORDER_STATUS_ID <> 50

--   BEGIN DISTRIBUTED TRANSACTION
   
   INSERT INTO TTS.TTS.dbo.TB022_TTORDERS 
         (TB022_ORDER_ID,   
          TB022_PK_BATCH_NO,   
          TB022_ORDER_STATUS_ID,   
          TB022_ORDER_TYPE,   
          TB022_LINE_ID,   
          TB022_ITEM_ID,   
          TB022_UOM_TARGET_ID,   
          TB022_TARGET_QTY,   
          TB022_SEQUENCE_ORDER,   
          TB022_SCHED_START_DATE,   
          TB022_EXPIRY_DATE,   
          TB022_MES_ORDER_NO,   
          TB022_PK_ORDER_NO,   
          TB022_PK_BO_SUBLOT) 
   VALUES(@order_id,   
          @batch_no,   
          10,   
          'P',   
          @line_id,   
          @ITEM_ID,   
          @UOM_TARGET_ID,   
          @quantity,   
          @SEQUENCE_ORDER,          
          @start_date,   
          @expiry_date,   
          NULL,   
          NULL,   
          NULL) 
          
   IF @@ERROR <> 0
   BEGIN
      RAISERROR('070101-DSI-0002 - TTS sunucusuna üretim emri kaydedilirken bir hata oluştu (1. aşama)!', 16, 1)
      ROLLBACK TRANSACTION
      RETURN  
   END
            
   INSERT INTO TTS.TTS.dbo.TB026_TT_ORDER_ML 
         (TB026_ORDER_ID,   
          TB026_ITEM_ID,   
          TB026_QUANTITY,   
          TB026_MARK) 
   VALUES(@order_id,   
          @ITEM_ID,   
          1,   
          'Y')                  
          
   IF @@ERROR <> 0
   BEGIN
      RAISERROR('070101-DSI-0002 - TTS sunucusuna üretim emri kaydedilirken bir hata oluştu (2. aşama)!', 16, 1)
      ROLLBACK TRANSACTION
      RETURN  
   END
         
   SELECT @order_id AS order_id,
          @UOM_TARGET_ID AS UOM_TARGET_ID,
          TB030_USC_STATUS_ID,
          0 AS TB032_NUMBER_OF_USC
   INTO #TEMP__          
   FROM TTS.TTS.dbo.TB030_USC_STATUS   
         
   INSERT INTO TTS.TTS.dbo.TB032_USC_COUNTERS 
         (TB032_ORDER_ID,
          TB032_ITEM_TYPE_ID,   
          TB032_USC_STATUS_ID,   
          TB032_NUMBER_OF_USC) 
   SELECT *
   FROM #TEMP__

   IF @@ERROR <> 0 OR @@ROWCOUNT = 0
   BEGIN
      RAISERROR('070101-DSI-0002 - TTS sunucusuna üretim emri kaydedilirken bir hata oluştu (3. aşama)!', 16, 1)
      ROLLBACK TRANSACTION
      RETURN  
   END
   
   DROP TABLE #TEMP__

   SELECT @RATE = ISNULL(A.TB037_NUMERIC_VALUE, 0) / 100 
   FROM TTS.TTS.dbo.TB037_SYSTEM_PARM A 
   WHERE A.TB037_PARAMETER_CODE = 'SCRFCT'
                
   SET @QUANTITY_2 = CASE 
                        WHEN (@quantity * (1 + @RATE)) > ROUND(@quantity * (1 + @RATE), 0, 1) THEN ROUND((@quantity * (1 + @RATE) + 1), 0, 1) 
                        ELSE @quantity * (1 + @RATE) 
                     END
                                           
   UPDATE TTS.TTS.dbo.TB026_TT_ORDER_ML 
   SET TB026_USC_REQUIRED = @QUANTITY_2 
   WHERE TB026_ORDER_ID = @order_id
     AND TB026_ITEM_ID = @ITEM_ID
                  
   IF @@ERROR <> 0 OR @@ROWCOUNT = 0
   BEGIN
      RAISERROR('070101-DSI-0002 - TTS sunucusuna üretim emri kaydedilirken bir hata oluştu (4. aşama)!', 16, 1)
      ROLLBACK TRANSACTION
      RETURN  
   END
      
   INSERT INTO TTS.TTS.dbo.TB049_TTO_CODES_REQUEST 
         (TB049_ORDER_ID,   
          TB049_ORDER_TYPE,   
          TB049_LINE_ID,   
          TB049_PRODUCTION_START_DATE,   
          TB049_PRODUCTION_END_DATE,   
          TB049_EXPIRY_DATE,   
          TB049_GTIN,   
          TB049_ORDER_LENGTH,   
          TB049_CODE_PATTERN,   
          TB049_SORTING,   
          TB049_REQUEST_TYPE,   
          TB049_TSTAMP_INS,   
          TB049_STATUS,   
          TB049_FACTORY_ID,   
          TB049_ORDER_SIZE) 
   VALUES(@order_id,   
          LOWER('M'),   
          @line_id,   
          @start_date,   
          NULL,   
          @expiry_date,   
          @gtin_no,   
          CONVERT(int, '16'),   
          'A',   
          'R',   
          2,   
          GETDATE(),   
          1,   
          'Laetus',   
          @QUANTITY_2) 

   IF @@ERROR <> 0 
   BEGIN
      RAISERROR('070101-DSI-0002 - TTS sunucusuna üretim emri kaydedilirken bir hata oluştu (5. aşama)!', 16, 1)
      ROLLBACK TRANSACTION
      RETURN  
   END     
   
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
          ord_code_order_id)
	SELECT @order_id,
	       @batch_no,
      	 @SEQUENCE_ORDER,
          'P',   
          10,   
          @line_id,   
      	 (SELECT mmr_id FROM Material_Master WHERE mmr_gtin = @gtin_no),
      	 @quantity,
      	 @UOM_TARGET_ID,
          @start_date,   
          NULL,
          @expiry_date,   
          NULL

   IF @@ERROR <> 0 
   BEGIN
      RAISERROR('070101-DSI-0002 - TTS sunucusuna üretim emri kaydedilirken bir hata oluştu (6. aşama)!', 16, 1)
      ROLLBACK TRANSACTION
      RETURN  
   END     

      	           
   --COMMIT TRANSACTION         
   SET XACT_ABORT OFF
GO

/****** Object: Trigger [dbo].[Package_List_MAUD_FOR_ATL]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_List_MAUD_FOR_ATL]') AND type IN ('TR', 'TA')))
BEGIN
	DROP TRIGGER [dbo].[Package_List_MAUD_FOR_ATL]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [Package_List_MAUD_FOR_ATL] ON dbo.Package_List
AFTER UPDATE, DELETE
AS 
BEGIN
   IF UPDATE(pck_sscc) RETURN
   
   DECLARE @HOSTNAME         		  SYSNAME,
           @PROGRAM_NAME           SYSNAME,

           @user_ip          		  VARCHAR(15),
           @user_name        		  VARCHAR(20),
           @user_id          		  INT
           

   SELECT @HOSTNAME = RTRIM(LTRIM(hostname)),
          @PROGRAM_NAME = program_name
   FROM master.dbo.sysprocesses
   WHERE spid = @@SPID
   
   IF CHARINDEX(' ', @HOSTNAME) > 0
   BEGIN
      SET @user_name = LEFT(@HOSTNAME, CHARINDEX(' ', @HOSTNAME)-1)
      SET @user_ip = RIGHT(@HOSTNAME, LEN(@HOSTNAME)-CHARINDEX(' ', @HOSTNAME))

      SELECT @user_id = usr_id
      FROM TESTTCP.SECURITY.dbo.Users
      WHERE usr_name = dbo.fn_sifre_olustur(@user_name)
   END
   ELSE
   BEGIN
      SET @user_ip = @HOSTNAME
   END   
   
   INSERT INTO Package_List_Log
          (log_usr_id,
           log_datetime,
           log_operation,
           log_hostname,
           log_program_name,
           log_pck_id,
           log_pck_code,
           log_old_status_id,
           log_new_status_id)   
   SELECT  @user_id,
           GETDATE(),
           CASE 
            WHEN I.pck_id IS NULL THEN 'D'
            ELSE 'U'
           END,
           @user_ip,
           @PROGRAM_NAME,
           D.pck_id,
           D.pck_code,
           D.pck_status_id,
           I.pck_status_id
   FROM DELETED D
   LEFT JOIN INSERTED I ON (I.pck_id = D.pck_id)      
   WHERE I.pck_id IS NULL
      OR D.pck_status_id <>    I.pck_status_id               
   
END
GO

ENABLE TRIGGER [dbo].[Package_List_MAUD_FOR_ATL] ON [dbo].[Package_List]
GO

/****** Object: Trigger [dbo].[Package_Movement_Detail_MAI]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package_Movement_Detail_MAI]') AND type IN ('TR', 'TA')))
BEGIN
	DROP TRIGGER [dbo].[Package_Movement_Detail_MAI]
END

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [Package_Movement_Detail_MAI] ON  [dbo].[Package_Movement_Detail] 
AFTER INSERT
AS 
BEGIN
   UPDATE Package_List
   SET pck_status = CASE 
                     WHEN pck_status = 'W' AND I.pmd_response_code = '10007' THEN PMM.pmm_type
                     WHEN pck_status = 'P' AND I.pmd_response_code = '10205' THEN PMM.pmm_type
                     WHEN pck_status = 'P' AND I.pmd_response_code = '10204' THEN PMM.pmm_type
                     WHEN pck_status = 'S' AND PMM.pmm_type = 'T' AND I.pmd_response_code = '00000' THEN 'P'
                     WHEN I.pmd_response_code = '00000' THEN PMM.pmm_type
                     ELSE pck_status
                    END,
       pck_status_id = CASE pck_status_id
                        WHEN 98 THEN pck_previous_status_id                    
                        ELSE pck_status_id
                       END,
       pck_last_sold_account_code = CASE 
                                       WHEN I.pmd_response_code = '00000' AND PMM.pmm_type = 'S' THEN (SELECT TOP 1 SOR.sor_account_code
                                                                                                       FROM Shipping_Order_List SOR
                                                                                                       WHERE SOR.sor_order_number = PMM.pmm_order_id) 
                                       WHEN I.pmd_response_code = '00000' AND PMM.pmm_type = 'T' THEN NULL                                                                                                     
                                       ELSE pck_last_sold_account_code
                                    END
   FROM INSERTED I
   INNER JOIN Package_Movement_Master PMM ON (PMM.pmm_id = I.pmd_pmm_id)
   WHERE pck_id = I.pmd_pck_id
   
   
   UPDATE Cancelled_Sales_Detail
   SET csd_status = 'F'
   FROM INSERTED I
   INNER JOIN Package_Movement_Master PMM ON (PMM.pmm_id = I.pmd_pmm_id)   
   WHERE csd_pck_id = I.pmd_pck_id
     AND PMM.pmm_type = 'T'
     AND I.pmd_response_code = '00000'
END
GO

ENABLE TRIGGER [dbo].[Package_Movement_Detail_MAI] ON [dbo].[Package_Movement_Detail]
GO

/****** Object: Primary Key [PK_Account_Master]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_Account_Master]') AND type IN ('PK', 'UQ')))
BEGIN
	ALTER TABLE [dbo].[Account_Master]
	DROP CONSTRAINT [PK_Account_Master]
END

GO

ALTER TABLE [dbo].[Account_Master]
 ADD CONSTRAINT [PK_Account_Master] PRIMARY KEY ([amr_id] ASC) WITH (FILLFACTOR=100,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key    Script Date: 26.04.2012 10:07:47 ******/
GO

ALTER TABLE [dbo].[Cancelled_Sales_Detail]
 ADD PRIMARY KEY ([csd_id] ASC) WITH (FILLFACTOR=100,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key [PK__Cancelle__C86A7F934D5F7D71]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK__Cancelle__C86A7F934D5F7D71]') AND type IN ('PK', 'UQ')))
BEGIN
	ALTER TABLE [dbo].[Cancelled_Sales_Master]
	DROP CONSTRAINT [PK__Cancelle__C86A7F934D5F7D71]
END

GO

ALTER TABLE [dbo].[Cancelled_Sales_Master]
 ADD CONSTRAINT [PK__Cancelle__C86A7F934D5F7D71] PRIMARY KEY ([csm_id] ASC) WITH (FILLFACTOR=100,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key    Script Date: 26.04.2012 10:07:47 ******/
GO

ALTER TABLE [dbo].[Case_Aggregations]
 ADD PRIMARY KEY ([cag_sscc] ASC) WITH (FILLFACTOR=100,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key    Script Date: 26.04.2012 10:07:47 ******/
GO

ALTER TABLE [dbo].[Companies]
 ADD PRIMARY KEY ([com_id] ASC) WITH (FILLFACTOR=100,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key [PK_Errors]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_Errors]') AND type IN ('PK', 'UQ')))
BEGIN
	ALTER TABLE [dbo].[Errors]
	DROP CONSTRAINT [PK_Errors]
END

GO

ALTER TABLE [dbo].[Errors]
 ADD CONSTRAINT [PK_Errors] PRIMARY KEY ([err_id] ASC) WITH (FILLFACTOR=70,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key [PK_Functions]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_Functions]') AND type IN ('PK', 'UQ')))
BEGIN
	ALTER TABLE [dbo].[Functions]
	DROP CONSTRAINT [PK_Functions]
END

GO

ALTER TABLE [dbo].[Functions]
 ADD CONSTRAINT [PK_Functions] PRIMARY KEY ([fun_id] ASC) WITH (FILLFACTOR=70,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key    Script Date: 26.04.2012 10:07:47 ******/
GO

ALTER TABLE [dbo].[Global_Error_List]
 ADD PRIMARY KEY ([erl_id] ASC) WITH (FILLFACTOR=100,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key    Script Date: 26.04.2012 10:07:47 ******/
GO

ALTER TABLE [dbo].[Global_Settings]
 ADD PRIMARY KEY ([set_id] ASC) WITH (FILLFACTOR=100,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key [PK_Line_List]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_Line_List]') AND type IN ('PK', 'UQ')))
BEGIN
	ALTER TABLE [dbo].[Line_List]
	DROP CONSTRAINT [PK_Line_List]
END

GO

ALTER TABLE [dbo].[Line_List]
 ADD CONSTRAINT [PK_Line_List] PRIMARY KEY ([lin_id] ASC) WITH (FILLFACTOR=70,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key [PK_Material_Master]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_Material_Master]') AND type IN ('PK', 'UQ')))
BEGIN
	ALTER TABLE [dbo].[Material_Master]
	DROP CONSTRAINT [PK_Material_Master]
END

GO

ALTER TABLE [dbo].[Material_Master]
 ADD CONSTRAINT [PK_Material_Master] PRIMARY KEY ([mmr_id] ASC) WITH (FILLFACTOR=70,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key [PK_Order_List]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_Order_List]') AND type IN ('PK', 'UQ')))
BEGIN
	ALTER TABLE [dbo].[Order_List]
	DROP CONSTRAINT [PK_Order_List]
END

GO

ALTER TABLE [dbo].[Order_List]
 ADD CONSTRAINT [PK_Order_List] PRIMARY KEY ([ord_order_id] ASC) WITH (FILLFACTOR=70,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key [PK_Order_Status]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_Order_Status]') AND type IN ('PK', 'UQ')))
BEGIN
	ALTER TABLE [dbo].[Order_Status]
	DROP CONSTRAINT [PK_Order_Status]
END

GO

ALTER TABLE [dbo].[Order_Status]
 ADD CONSTRAINT [PK_Order_Status] PRIMARY KEY ([ors_order_status_id] ASC) WITH (FILLFACTOR=70,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key [PK_Package_Aggregations]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_Package_Aggregations]') AND type IN ('PK', 'UQ')))
BEGIN
	ALTER TABLE [dbo].[Package_Aggregations]
	DROP CONSTRAINT [PK_Package_Aggregations]
END

GO

ALTER TABLE [dbo].[Package_Aggregations]
 ADD CONSTRAINT [PK_Package_Aggregations] PRIMARY KEY ([pag_id] ASC) WITH (FILLFACTOR=100,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key [PK_Package_List]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_Package_List]') AND type IN ('PK', 'UQ')))
BEGIN
	ALTER TABLE [dbo].[Package_List]
	DROP CONSTRAINT [PK_Package_List]
END

GO

ALTER TABLE [dbo].[Package_List]
 ADD CONSTRAINT [PK_Package_List] PRIMARY KEY NONCLUSTERED ([pck_id] ASC) WITH (FILLFACTOR=70,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key [PK_Package_List_Log]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_Package_List_Log]') AND type IN ('PK', 'UQ')))
BEGIN
	ALTER TABLE [dbo].[Package_List_Log]
	DROP CONSTRAINT [PK_Package_List_Log]
END

GO

ALTER TABLE [dbo].[Package_List_Log]
 ADD CONSTRAINT [PK_Package_List_Log] PRIMARY KEY NONCLUSTERED ([log_id] ASC) WITH (FILLFACTOR=70,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key [PK_Package_List_Not_Printed]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_Package_List_Not_Printed]') AND type IN ('PK', 'UQ')))
BEGIN
	ALTER TABLE [dbo].[Package_List_Not_Printed]
	DROP CONSTRAINT [PK_Package_List_Not_Printed]
END

GO

ALTER TABLE [dbo].[Package_List_Not_Printed]
 ADD CONSTRAINT [PK_Package_List_Not_Printed] PRIMARY KEY ([pcp_id] ASC) WITH (FILLFACTOR=70,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key [PK_Package_Movement_Detail]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_Package_Movement_Detail]') AND type IN ('PK', 'UQ')))
BEGIN
	ALTER TABLE [dbo].[Package_Movement_Detail]
	DROP CONSTRAINT [PK_Package_Movement_Detail]
END

GO

ALTER TABLE [dbo].[Package_Movement_Detail]
 ADD CONSTRAINT [PK_Package_Movement_Detail] PRIMARY KEY NONCLUSTERED ([pmd_id] ASC) WITH (FILLFACTOR=70,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key [PK_Package_Movement_Master]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_Package_Movement_Master]') AND type IN ('PK', 'UQ')))
BEGIN
	ALTER TABLE [dbo].[Package_Movement_Master]
	DROP CONSTRAINT [PK_Package_Movement_Master]
END

GO

ALTER TABLE [dbo].[Package_Movement_Master]
 ADD CONSTRAINT [PK_Package_Movement_Master] PRIMARY KEY ([pmm_id] ASC) WITH (FILLFACTOR=70,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key [PK_Package_Status]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_Package_Status]') AND type IN ('PK', 'UQ')))
BEGIN
	ALTER TABLE [dbo].[Package_Status]
	DROP CONSTRAINT [PK_Package_Status]
END

GO

ALTER TABLE [dbo].[Package_Status]
 ADD CONSTRAINT [PK_Package_Status] PRIMARY KEY ([pst_status_id] ASC) WITH (FILLFACTOR=70,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key    Script Date: 26.04.2012 10:07:47 ******/
GO

ALTER TABLE [dbo].[Production_Order_Insert_Settings]
 ADD PRIMARY KEY ([pos_id] ASC) WITH (FILLFACTOR=100,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key [PK_Properties]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_Properties]') AND type IN ('PK', 'UQ')))
BEGIN
	ALTER TABLE [dbo].[Properties]
	DROP CONSTRAINT [PK_Properties]
END

GO

ALTER TABLE [dbo].[Properties]
 ADD CONSTRAINT [PK_Properties] PRIMARY KEY ([pro_name] ASC) WITH (FILLFACTOR=70,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key    Script Date: 26.04.2012 10:07:47 ******/
GO

ALTER TABLE [dbo].[Scheduled_Declaration]
 ADD PRIMARY KEY ([sch_id] ASC) WITH (FILLFACTOR=100,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key    Script Date: 26.04.2012 10:07:47 ******/
GO

ALTER TABLE [dbo].[Shipping_Order_Details]
 ADD PRIMARY KEY ([sod_id] ASC) WITH (FILLFACTOR=100,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key [PK_Shipping_Order_List]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_Shipping_Order_List]') AND type IN ('PK', 'UQ')))
BEGIN
	ALTER TABLE [dbo].[Shipping_Order_List]
	DROP CONSTRAINT [PK_Shipping_Order_List]
END

GO

ALTER TABLE [dbo].[Shipping_Order_List]
 ADD CONSTRAINT [PK_Shipping_Order_List] PRIMARY KEY ([sor_id] ASC) WITH (FILLFACTOR=100,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key    Script Date: 26.04.2012 10:07:47 ******/
GO

ALTER TABLE [dbo].[Transfer_Logs]
 ADD PRIMARY KEY ([trl_id] ASC) WITH (FILLFACTOR=100,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Primary Key [PK_User_Rights]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_User_Rights]') AND type IN ('PK', 'UQ')))
BEGIN
	ALTER TABLE [dbo].[User_Rights]
	DROP CONSTRAINT [PK_User_Rights]
END

GO

ALTER TABLE [dbo].[User_Rights]
 ADD CONSTRAINT [PK_User_Rights] PRIMARY KEY ([usr_id] ASC, [fun_id] ASC) WITH (FILLFACTOR=70,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
GO

/****** Object: Index [dbo].[Account_Master].[IX_Account_Master]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Account_Master]') AND name = N'IX_Account_Master'))
BEGIN
	DROP INDEX [IX_Account_Master] ON [dbo].[Account_Master]
END

GO

CREATE INDEX [IX_Account_Master]
 ON [dbo].[Account_Master] ([amr_account_code])
INCLUDE ([amr_account_name])
WITH (FILLFACTOR=100,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Case_Aggregations].[IX_Case_Aggregations]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Case_Aggregations]') AND name = N'IX_Case_Aggregations'))
BEGIN
	DROP INDEX [IX_Case_Aggregations] ON [dbo].[Case_Aggregations]
END

GO

CREATE INDEX [IX_Case_Aggregations]
 ON [dbo].[Case_Aggregations] ([cag_parent_sscc])
WITH (FILLFACTOR=100,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Errors].[IX_Errors_pmm_id]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Errors]') AND name = N'IX_Errors_pmm_id'))
BEGIN
	DROP INDEX [IX_Errors_pmm_id] ON [dbo].[Errors]
END

GO

CREATE INDEX [IX_Errors_pmm_id]
 ON [dbo].[Errors] ([err_pmm_id], [err_error_message])
WITH (FILLFACTOR=70,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Global_Error_List].[IX_Global_Error_List]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Global_Error_List]') AND name = N'IX_Global_Error_List'))
BEGIN
	DROP INDEX [IX_Global_Error_List] ON [dbo].[Global_Error_List]
END

GO

CREATE UNIQUE INDEX [IX_Global_Error_List]
 ON [dbo].[Global_Error_List] ([erl_error_code])
WITH (FILLFACTOR=100,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Global_Settings].[IX_Global_Settings]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Global_Settings]') AND name = N'IX_Global_Settings'))
BEGIN
	DROP INDEX [IX_Global_Settings] ON [dbo].[Global_Settings]
END

GO

CREATE UNIQUE INDEX [IX_Global_Settings]
 ON [dbo].[Global_Settings] ([set_environment], [set_setting_name])
WITH (FILLFACTOR=100,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Package_Aggregations].[IX_Package_Aggregations_pck_id]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Package_Aggregations]') AND name = N'IX_Package_Aggregations_pck_id'))
BEGIN
	DROP INDEX [IX_Package_Aggregations_pck_id] ON [dbo].[Package_Aggregations]
END

GO

CREATE UNIQUE INDEX [IX_Package_Aggregations_pck_id]
 ON [dbo].[Package_Aggregations] ([pag_pck_id])
WITH (FILLFACTOR=100,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Package_Aggregations].[IX_Package_Aggregations_sscc]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Package_Aggregations]') AND name = N'IX_Package_Aggregations_sscc'))
BEGIN
	DROP INDEX [IX_Package_Aggregations_sscc] ON [dbo].[Package_Aggregations]
END

GO

CREATE INDEX [IX_Package_Aggregations_sscc]
 ON [dbo].[Package_Aggregations] ([pag_sscc])
INCLUDE ([pag_pck_id])
WITH (FILLFACTOR=100,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Package_List].[IX_Package_List_browse]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Package_List]') AND name = N'IX_Package_List_browse'))
BEGIN
	DROP INDEX [IX_Package_List_browse] ON [dbo].[Package_List]
END

GO

CREATE INDEX [IX_Package_List_browse]
 ON [dbo].[Package_List] ([pck_order_id], [pck_status], [pck_status_id], [pck_usr_id], [pck_code], [pck_sscc])
INCLUDE ([pck_id], [pck_timestamp], [pck_original_order_id], [pck_was_printed], [pck_source])
WITH (PAD_INDEX=ON,
	FILLFACTOR=70,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Package_List].[IX_Package_List_code]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Package_List]') AND name = N'IX_Package_List_code'))
BEGIN
	DROP INDEX [IX_Package_List_code] ON [dbo].[Package_List]
END

GO

CREATE INDEX [IX_Package_List_code]
 ON [dbo].[Package_List] ([pck_timestamp], [pck_code])
INCLUDE ([pck_order_id], [pck_status_id], [pck_sync_date], [pck_status])
WITH (FILLFACTOR=100,
	DATA_COMPRESSION = NONE)
ON [ITS_PartitionScheme] ([pck_timestamp])
GO

/****** Object: Index [dbo].[Package_List].[IX_Package_List_code_new]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Package_List]') AND name = N'IX_Package_List_code_new'))
BEGIN
	DROP INDEX [IX_Package_List_code_new] ON [dbo].[Package_List]
END

GO

CREATE UNIQUE INDEX [IX_Package_List_code_new]
 ON [dbo].[Package_List] ([pck_code])
WHERE ([pck_timestamp]>='2011-01-01 00:00:01')
WITH (FILLFACTOR=70,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Package_List].[IX_Package_List_code_old]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Package_List]') AND name = N'IX_Package_List_code_old'))
BEGIN
	DROP INDEX [IX_Package_List_code_old] ON [dbo].[Package_List]
END

GO

CREATE UNIQUE INDEX [IX_Package_List_code_old]
 ON [dbo].[Package_List] ([pck_code])
WHERE ([pck_timestamp]<='2010-12-31 23:59:59')
WITH (FILLFACTOR=70,
	DATA_COMPRESSION = NONE)
ON [SECONDARY]
GO

/****** Object: Index [dbo].[Package_List].[IX_Package_List_original_order_id]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Package_List]') AND name = N'IX_Package_List_original_order_id'))
BEGIN
	DROP INDEX [IX_Package_List_original_order_id] ON [dbo].[Package_List]
END

GO

CREATE INDEX [IX_Package_List_original_order_id]
 ON [dbo].[Package_List] ([pck_timestamp], [pck_original_order_id])
WITH (FILLFACTOR=70,
	DATA_COMPRESSION = NONE)
ON [ITS_PartitionScheme] ([pck_timestamp])
GO

/****** Object: Index [dbo].[Package_List].[IX_Package_List_sscc]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Package_List]') AND name = N'IX_Package_List_sscc'))
BEGIN
	DROP INDEX [IX_Package_List_sscc] ON [dbo].[Package_List]
END

GO

CREATE INDEX [IX_Package_List_sscc]
 ON [dbo].[Package_List] ([pck_sscc])
WITH (FILLFACTOR=100,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Package_List].[IX_Package_List_status_id_for_deactivation]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Package_List]') AND name = N'IX_Package_List_status_id_for_deactivation'))
BEGIN
	DROP INDEX [IX_Package_List_status_id_for_deactivation] ON [dbo].[Package_List]
END

GO

CREATE INDEX [IX_Package_List_status_id_for_deactivation]
 ON [dbo].[Package_List] ([pck_timestamp], [pck_status_id])
INCLUDE ([pck_order_id])
WITH (FILLFACTOR=70,
	DATA_COMPRESSION = NONE)
ON [ITS_PartitionScheme] ([pck_timestamp])
GO

/****** Object: Index [dbo].[Package_List_Log].[IX_Package_List_Log]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Package_List_Log]') AND name = N'IX_Package_List_Log'))
BEGIN
	DROP INDEX [IX_Package_List_Log] ON [dbo].[Package_List_Log]
END

GO

CREATE INDEX [IX_Package_List_Log]
 ON [dbo].[Package_List_Log] ([log_datetime], [log_pck_id])
WITH (FILLFACTOR=70,
	DATA_COMPRESSION = NONE)
ON [ITS_PartitionScheme] ([log_datetime])
GO

/****** Object: Index [dbo].[Package_List_Not_Printed].[IX_Package_List_Not_Printed_code]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Package_List_Not_Printed]') AND name = N'IX_Package_List_Not_Printed_code'))
BEGIN
	DROP INDEX [IX_Package_List_Not_Printed_code] ON [dbo].[Package_List_Not_Printed]
END

GO

CREATE INDEX [IX_Package_List_Not_Printed_code]
 ON [dbo].[Package_List_Not_Printed] ([pcp_code])
WITH (FILLFACTOR=70,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Package_List_Not_Printed].[IX_Package_List_Not_Printed_order_id]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Package_List_Not_Printed]') AND name = N'IX_Package_List_Not_Printed_order_id'))
BEGIN
	DROP INDEX [IX_Package_List_Not_Printed_order_id] ON [dbo].[Package_List_Not_Printed]
END

GO

CREATE INDEX [IX_Package_List_Not_Printed_order_id]
 ON [dbo].[Package_List_Not_Printed] ([pcp_order_id])
INCLUDE ([pcp_id], [pcp_code], [pcp_sync_date])
WITH (FILLFACTOR=70,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Package_Movement_Detail].[IX_Package_Movement_Detail_pck_id]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Package_Movement_Detail]') AND name = N'IX_Package_Movement_Detail_pck_id'))
BEGIN
	DROP INDEX [IX_Package_Movement_Detail_pck_id] ON [dbo].[Package_Movement_Detail]
END

GO

CREATE INDEX [IX_Package_Movement_Detail_pck_id]
 ON [dbo].[Package_Movement_Detail] ([pmd_datetime], [pmd_pck_id])
WITH (PAD_INDEX=ON,
	FILLFACTOR=70,
	DATA_COMPRESSION = NONE)
ON [ITS_PartitionScheme_smalldatetime] ([pmd_datetime])
GO

/****** Object: Index [dbo].[Package_Movement_Detail].[IX_Package_Movement_Detail_pmm_id]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Package_Movement_Detail]') AND name = N'IX_Package_Movement_Detail_pmm_id'))
BEGIN
	DROP INDEX [IX_Package_Movement_Detail_pmm_id] ON [dbo].[Package_Movement_Detail]
END

GO

CREATE INDEX [IX_Package_Movement_Detail_pmm_id]
 ON [dbo].[Package_Movement_Detail] ([pmd_datetime], [pmd_pmm_id])
WITH (PAD_INDEX=ON,
	FILLFACTOR=70,
	DATA_COMPRESSION = NONE)
ON [ITS_PartitionScheme_smalldatetime] ([pmd_datetime])
GO

/****** Object: Index [dbo].[Package_Movement_Detail].[IX_Package_Movement_Detail_response]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Package_Movement_Detail]') AND name = N'IX_Package_Movement_Detail_response'))
BEGIN
	DROP INDEX [IX_Package_Movement_Detail_response] ON [dbo].[Package_Movement_Detail]
END

GO

CREATE INDEX [IX_Package_Movement_Detail_response]
 ON [dbo].[Package_Movement_Detail] ([pmd_datetime], [pmd_pmm_id], [pmd_response_code])
INCLUDE ([pmd_id])
WITH (PAD_INDEX=ON,
	FILLFACTOR=70,
	DATA_COMPRESSION = NONE)
ON [ITS_PartitionScheme_smalldatetime] ([pmd_datetime])
GO

/****** Object: Index [dbo].[Package_Movement_Master].[IX_Package_Movement_Master_pmm_parent_id]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Package_Movement_Master]') AND name = N'IX_Package_Movement_Master_pmm_parent_id'))
BEGIN
	DROP INDEX [IX_Package_Movement_Master_pmm_parent_id] ON [dbo].[Package_Movement_Master]
END

GO

CREATE INDEX [IX_Package_Movement_Master_pmm_parent_id]
 ON [dbo].[Package_Movement_Master] ([pmm_parent_id], [pmm_declaration_id])
WITH (FILLFACTOR=70,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Package_Status].[IX_Package_Status]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Package_Status]') AND name = N'IX_Package_Status'))
BEGIN
	DROP INDEX [IX_Package_Status] ON [dbo].[Package_Status]
END

GO

CREATE INDEX [IX_Package_Status]
 ON [dbo].[Package_Status] ([pst_status_id])
INCLUDE ([pst_description])
WITH (FILLFACTOR=70,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Scheduled_Declaration].[IX_Scheduled_Declaration]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Scheduled_Declaration]') AND name = N'IX_Scheduled_Declaration'))
BEGIN
	DROP INDEX [IX_Scheduled_Declaration] ON [dbo].[Scheduled_Declaration]
END

GO

CREATE INDEX [IX_Scheduled_Declaration]
 ON [dbo].[Scheduled_Declaration] ([sch_order_id], [sch_type], [sch_scheduled_time], [sch_status])
WITH (FILLFACTOR=100,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Shipping_Order_Details].[IX_Shipping_Order_Detail_sor_id]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Shipping_Order_Details]') AND name = N'IX_Shipping_Order_Detail_sor_id'))
BEGIN
	DROP INDEX [IX_Shipping_Order_Detail_sor_id] ON [dbo].[Shipping_Order_Details]
END

GO

CREATE INDEX [IX_Shipping_Order_Detail_sor_id]
 ON [dbo].[Shipping_Order_Details] ([sod_sor_id])
INCLUDE ([sod_sscc])
WITH (PAD_INDEX=ON,
	FILLFACTOR=70,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Shipping_Order_Details].[IX_Shipping_Order_Detail_sscc]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Shipping_Order_Details]') AND name = N'IX_Shipping_Order_Detail_sscc'))
BEGIN
	DROP INDEX [IX_Shipping_Order_Detail_sscc] ON [dbo].[Shipping_Order_Details]
END

GO

CREATE UNIQUE INDEX [IX_Shipping_Order_Detail_sscc]
 ON [dbo].[Shipping_Order_Details] ([sod_sscc])
WITH (FILLFACTOR=100,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Shipping_Order_List].[IX_Shipping_Order_List_order_number]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Shipping_Order_List]') AND name = N'IX_Shipping_Order_List_order_number'))
BEGIN
	DROP INDEX [IX_Shipping_Order_List_order_number] ON [dbo].[Shipping_Order_List]
END

GO

CREATE UNIQUE INDEX [IX_Shipping_Order_List_order_number]
 ON [dbo].[Shipping_Order_List] ([sor_order_number])
WITH (FILLFACTOR=100,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Shipping_Order_List].[IX_Shipping_Order_List_was_declaration]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Shipping_Order_List]') AND name = N'IX_Shipping_Order_List_was_declaration'))
BEGIN
	DROP INDEX [IX_Shipping_Order_List_was_declaration] ON [dbo].[Shipping_Order_List]
END

GO

CREATE INDEX [IX_Shipping_Order_List_was_declaration]
 ON [dbo].[Shipping_Order_List] ([sor_was_declaration])
WITH (PAD_INDEX=ON,
	FILLFACTOR=70,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Index [dbo].[Transfer_Logs].[IX_Transfer_Logs]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Transfer_Logs]') AND name = N'IX_Transfer_Logs'))
BEGIN
	DROP INDEX [IX_Transfer_Logs] ON [dbo].[Transfer_Logs]
END

GO

CREATE INDEX [IX_Transfer_Logs]
 ON [dbo].[Transfer_Logs] ([trl_type], [trl_finishing_time] DESC)
INCLUDE ([trl_starting_time])
WITH (FILLFACTOR=100,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

/****** Object: Foreign Key [FK_User_Rights_Functions]   Script Date: 26.04.2012 10:07:47 ******/
GO

IF (EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_Rights_Functions]') AND type ='F'))
BEGIN
	ALTER TABLE [dbo].[User_Rights]
	DROP CONSTRAINT [FK_User_Rights_Functions]
END

GO

ALTER TABLE [dbo].[User_Rights]
WITH NOCHECK  ADD CONSTRAINT [FK_User_Rights_Functions] FOREIGN KEY ([fun_id]) 
		REFERENCES [dbo].[Functions] ([fun_id])  NOT FOR REPLICATION
GO

ALTER TABLE [dbo].[User_Rights]
CHECK CONSTRAINT [FK_User_Rights_Functions]
GO