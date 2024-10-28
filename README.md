# OrderFilter

Это webApi приложение. 
Чтобы получить отфильтрованные заказы. 
Нужно обратиться по адресу: `/api/orders`   
**Пример:**    
  Запрос:   
  `/api/orders?region=region_3&StartDate=2024-10-26 10:00:00`  
  Ответ:    
  ```
 {
    "id": 1,
    "orders": [
        {
            "id": 10,
            "weight": 50,
            "region": "region_3",
            "deliveryDateTime": "2024-10-26T10:00:00"
        }
    ]
}
  ```


Используется База данных Sqlite,  
Пример настроек в файле appsettings.json:
```
  "ConnectionString": "appDataBase.db",
  "deliveryLog": "log.txt"
```
