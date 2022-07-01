# RapidPay
Code Test

Under Payment.Data project, folder Data you can download de DB Backup

https://[server]/api/CardManagement/createcard

{
    "AccountNumber":"1111111111",
    "Type":"CREDIT",
    "ExpirationDate": "2025-07-01",
    "IsActive": true
}


-----------

https://[server]/api/payments/setpayment

{
    "Id":"6",
    "ClientCardId":"3",
    "Amount":"34",
    "TransactionDate": "2021-07-01",
    "TraansactionPlace": "true"
}

-----------

https://localhost:44396/api/payments/?accountNumber=817378253511413
