
SET XACT_ABORT ON

BEGIN TRANSACTION ProyectoCreditos

CREATE TABLE [Users] (
    [UserID] int  NOT NULL ,
    [UserRoles] int  NOT NULL ,
    [FirstName] VARCHAR(50)  NOT NULL ,
    [LastName] VARCHAR(50)  NOT NULL ,
    [Telephone] VARCHAR(50)  NOT NULL ,
    [Email] VARCHAR(50)  NOT NULL ,
    [Paassword] VARCHAR(50)  NOT NULL ,
    [BirthDay] datetime  NOT NULL ,
    [DocumentId] int  NOT NULL ,
    [Adddress] VARCHAR(10)  NOT NULL ,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED (
        [UserID] ASC
    )
)

CREATE TABLE [UserRoles] (
    [IDUserRoles] int  NOT NULL ,
    [RoleName] VARCHAR(25)  NOT NULL ,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED (
        [IDUserRoles] ASC
    )
)

CREATE TABLE [loans] (
    [LoansID] int  NOT NULL ,
    [UserID] int  NOT NULL ,
    [CorrencyID] int  NOT NULL ,
    [LoansStatesId] int  NOT NULL ,
    [Description] VARCHAR(50)  NOT NULL ,
    -- - loanAmount this is the total amount that the of the loan
    [loanAmount] MONEY  NOT NULL ,
    [MontlyPayment] MONEY  NOT NULL ,
    [StartDate] datetime  NOT NULL ,
    [EndDate] datetime  NOT NULL ,
    [InterestRate] FLOAT  NOT NULL ,
    [BankFees] MONEY  NOT NULL ,
    [nextDueDate] datetime  NOT NULL ,
    CONSTRAINT [PK_loans] PRIMARY KEY CLUSTERED (
        [LoansID] ASC
    )
)

CREATE TABLE [Correncys] (
    [CorrencyID] int  NOT NULL ,
    [CorrencyName] VARCHAR(25)  NOT NULL ,
    CONSTRAINT [PK_Correncys] PRIMARY KEY CLUSTERED (
        [CorrencyID] ASC
    )
)

CREATE TABLE [DebtSnowball] (
    [DebtSnowballID] int  NOT NULL ,
    [UserID] int  NOT NULL ,
    [PayOffOrder] int  NOT NULL ,
    [CustomOrderListID] int  NOT NULL ,
    [ExtraMonthlyPayment] int  NOT NULL ,
    [MonlyPayment] int  NOT NULL ,
    CONSTRAINT [PK_DebtSnowball] PRIMARY KEY CLUSTERED (
        [DebtSnowballID] ASC
    )
)

CREATE TABLE [PayOffStragedy] (
    [PayOffOrderID] int  NOT NULL ,
    [StragedyName] VARCHAR(25)  NOT NULL ,
    CONSTRAINT [PK_PayOffStragedy] PRIMARY KEY CLUSTERED (
        [PayOffOrderID] ASC
    )
)

CREATE TABLE [CustomOrderList] (
    [CustomOrderListID] int  NOT NULL ,
    [01CustomOrderPosition] int  NOT NULL ,
    [02CustomOrderPosition] int  NOT NULL ,
    [03CustomOrderPosition] int  NOT NULL ,
    [04CustomOrderPosition] int  NOT NULL ,
    [05CustomOrderPosition] int  NOT NULL ,
    [06CustomOrderPosition] int  NOT NULL ,
    [07CustomOrderPosition] int  NOT NULL ,
    [08CustomOrderPosition] int  NOT NULL ,
    [09CustomOrderPosition] int  NOT NULL ,
    [10CustomOrderPosition] int  NOT NULL ,
    CONSTRAINT [PK_CustomOrderList] PRIMARY KEY CLUSTERED (
        [CustomOrderListID] ASC
    )
)

CREATE TABLE [LoansStates] (
    [LoansStatesId] int  NOT NULL ,
    [loansStateName] VARCHAR(50)  NOT NULL ,
    CONSTRAINT [PK_LoansStates] PRIMARY KEY CLUSTERED (
        [LoansStatesId] ASC
    )
)

CREATE TABLE [PaymentHistory] (
    [PaymentId] int  NOT NULL ,
    [loadId] int  NOT NULL ,
    [Amount] MONEY  NOT NULL ,
    [DatePayed] datetime  NOT NULL ,
    CONSTRAINT [PK_PaymentHistory] PRIMARY KEY CLUSTERED (
        [PaymentId] ASC
    )
)

ALTER TABLE [Users] WITH CHECK ADD CONSTRAINT [FK_Users_UserRoles] FOREIGN KEY([UserRoles])
REFERENCES [UserRoles] ([IDUserRoles])

ALTER TABLE [Users] CHECK CONSTRAINT [FK_Users_UserRoles]

ALTER TABLE [loans] WITH CHECK ADD CONSTRAINT [FK_loans_UserID] FOREIGN KEY([UserID])
REFERENCES [Users] ([UserID])

ALTER TABLE [loans] CHECK CONSTRAINT [FK_loans_UserID]

ALTER TABLE [loans] WITH CHECK ADD CONSTRAINT [FK_loans_CorrencyID] FOREIGN KEY([CorrencyID])
REFERENCES [Correncys] ([CorrencyID])

ALTER TABLE [loans] CHECK CONSTRAINT [FK_loans_CorrencyID]

ALTER TABLE [loans] WITH CHECK ADD CONSTRAINT [FK_loans_LoansStatesId] FOREIGN KEY([LoansStatesId])
REFERENCES [LoansStates] ([LoansStatesId])

ALTER TABLE [loans] CHECK CONSTRAINT [FK_loans_LoansStatesId]

ALTER TABLE [DebtSnowball] WITH CHECK ADD CONSTRAINT [FK_DebtSnowball_UserID] FOREIGN KEY([UserID])
REFERENCES [Users] ([UserID])

ALTER TABLE [DebtSnowball] CHECK CONSTRAINT [FK_DebtSnowball_UserID]

ALTER TABLE [DebtSnowball] WITH CHECK ADD CONSTRAINT [FK_DebtSnowball_PayOffOrder] FOREIGN KEY([PayOffOrder])
REFERENCES [PayOffStragedy] ([PayOffOrderID])

ALTER TABLE [DebtSnowball] CHECK CONSTRAINT [FK_DebtSnowball_PayOffOrder]

ALTER TABLE [DebtSnowball] WITH CHECK ADD CONSTRAINT [FK_DebtSnowball_CustomOrderListID] FOREIGN KEY([CustomOrderListID])
REFERENCES [CustomOrderList] ([CustomOrderListID])

ALTER TABLE [DebtSnowball] CHECK CONSTRAINT [FK_DebtSnowball_CustomOrderListID]

ALTER TABLE [CustomOrderList] WITH CHECK ADD CONSTRAINT [FK_CustomOrderList_01CustomOrderPosition] FOREIGN KEY([01CustomOrderPosition])
REFERENCES [loans] ([LoansID])

ALTER TABLE [CustomOrderList] CHECK CONSTRAINT [FK_CustomOrderList_01CustomOrderPosition]

ALTER TABLE [CustomOrderList] WITH CHECK ADD CONSTRAINT [FK_CustomOrderList_02CustomOrderPosition] FOREIGN KEY([02CustomOrderPosition])
REFERENCES [loans] ([LoansID])

ALTER TABLE [CustomOrderList] CHECK CONSTRAINT [FK_CustomOrderList_02CustomOrderPosition]

ALTER TABLE [CustomOrderList] WITH CHECK ADD CONSTRAINT [FK_CustomOrderList_03CustomOrderPosition] FOREIGN KEY([03CustomOrderPosition])
REFERENCES [loans] ([LoansID])

ALTER TABLE [CustomOrderList] CHECK CONSTRAINT [FK_CustomOrderList_03CustomOrderPosition]

ALTER TABLE [CustomOrderList] WITH CHECK ADD CONSTRAINT [FK_CustomOrderList_04CustomOrderPosition] FOREIGN KEY([04CustomOrderPosition])
REFERENCES [loans] ([LoansID])

ALTER TABLE [CustomOrderList] CHECK CONSTRAINT [FK_CustomOrderList_04CustomOrderPosition]

ALTER TABLE [CustomOrderList] WITH CHECK ADD CONSTRAINT [FK_CustomOrderList_05CustomOrderPosition] FOREIGN KEY([05CustomOrderPosition])
REFERENCES [loans] ([LoansID])

ALTER TABLE [CustomOrderList] CHECK CONSTRAINT [FK_CustomOrderList_05CustomOrderPosition]

ALTER TABLE [CustomOrderList] WITH CHECK ADD CONSTRAINT [FK_CustomOrderList_06CustomOrderPosition] FOREIGN KEY([06CustomOrderPosition])
REFERENCES [loans] ([LoansID])

ALTER TABLE [CustomOrderList] CHECK CONSTRAINT [FK_CustomOrderList_06CustomOrderPosition]

ALTER TABLE [CustomOrderList] WITH CHECK ADD CONSTRAINT [FK_CustomOrderList_07CustomOrderPosition] FOREIGN KEY([07CustomOrderPosition])
REFERENCES [loans] ([LoansID])

ALTER TABLE [CustomOrderList] CHECK CONSTRAINT [FK_CustomOrderList_07CustomOrderPosition]

ALTER TABLE [CustomOrderList] WITH CHECK ADD CONSTRAINT [FK_CustomOrderList_08CustomOrderPosition] FOREIGN KEY([08CustomOrderPosition])
REFERENCES [loans] ([LoansID])

ALTER TABLE [CustomOrderList] CHECK CONSTRAINT [FK_CustomOrderList_08CustomOrderPosition]

ALTER TABLE [CustomOrderList] WITH CHECK ADD CONSTRAINT [FK_CustomOrderList_09CustomOrderPosition] FOREIGN KEY([09CustomOrderPosition])
REFERENCES [loans] ([LoansID])

ALTER TABLE [CustomOrderList] CHECK CONSTRAINT [FK_CustomOrderList_09CustomOrderPosition]

ALTER TABLE [CustomOrderList] WITH CHECK ADD CONSTRAINT [FK_CustomOrderList_10CustomOrderPosition] FOREIGN KEY([10CustomOrderPosition])
REFERENCES [loans] ([LoansID])

ALTER TABLE [CustomOrderList] CHECK CONSTRAINT [FK_CustomOrderList_10CustomOrderPosition]

ALTER TABLE [PaymentHistory] WITH CHECK ADD CONSTRAINT [FK_PaymentHistory_loadId] FOREIGN KEY([loadId])
REFERENCES [loans] ([LoansID])

ALTER TABLE [PaymentHistory] CHECK CONSTRAINT [FK_PaymentHistory_loadId]

COMMIT TRANSACTION QUICKDBD