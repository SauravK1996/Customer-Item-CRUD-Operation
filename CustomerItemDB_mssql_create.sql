Create database CustomerItemDB
Use CustomerItemDB

CREATE TABLE [TABCUST] (
	CUSTID numeric(3,0) NOT NULL,
	CUSTNAME nvarchar(20) NOT NULL,
  CONSTRAINT [PK_TABCUST] PRIMARY KEY CLUSTERED
  (
  [CUSTID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [TABSORDER] (
	SORDID numeric(3,0) NOT NULL,
	SORDDATE datetime NOT NULL,
	CUSTID numeric(3,0) NOT NULL,
	SORDAMNT numeric(10,2) NOT NULL,
	DATAEXST nvarchar(3) NOT NULL,
  CONSTRAINT [PK_TABSORDER] PRIMARY KEY CLUSTERED
  (
  [SORDID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [TABSODATA] (
	SODATAID numeric(3,0) NOT NULL,
	SORDID numeric(3,0) NOT NULL,
	ITEMID numeric(3,0) NOT NULL,
	ITEMRATE numeric(10,2) NOT NULL,
	DATAEXST nvarchar(3) NOT NULL,
  CONSTRAINT [PK_TABSODATA] PRIMARY KEY CLUSTERED
  (
  [SODATAID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [TABITEM] (
	ITEMID numeric(3,0) NOT NULL,
	ITEMNAME nvarchar(20) NOT NULL,
	ITEMRATE numeric(10,2) NOT NULL,
  CONSTRAINT [PK_TABITEM] PRIMARY KEY CLUSTERED
  (
  [ITEMID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO

ALTER TABLE [TABSORDER] WITH CHECK ADD CONSTRAINT [TABSORDER_fk0] FOREIGN KEY ([CUSTID]) REFERENCES [TABCUST]([CUSTID])
ON UPDATE CASCADE
GO
ALTER TABLE [TABSORDER] CHECK CONSTRAINT [TABSORDER_fk0]
GO

ALTER TABLE [TABSODATA] WITH CHECK ADD CONSTRAINT [TABSODATA_fk0] FOREIGN KEY ([SORDID]) REFERENCES [TABSORDER]([SORDID])
ON UPDATE CASCADE
GO
ALTER TABLE [TABSODATA] CHECK CONSTRAINT [TABSODATA_fk0]
GO
ALTER TABLE [TABSODATA] WITH CHECK ADD CONSTRAINT [TABSODATA_fk1] FOREIGN KEY ([ITEMID]) REFERENCES [TABITEM]([ITEMID])
ON UPDATE CASCADE
GO
ALTER TABLE [TABSODATA] CHECK CONSTRAINT [TABSODATA_fk1]
GO


