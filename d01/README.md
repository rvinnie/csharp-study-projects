
## ex00
Simple console currency converter. 
### Usage
```
dotnet run <sum> <ratesDirectory>
```
sum - amount with currency  
ratesDirectory - path to the folder with files with coefficients for conversion
### Example
```
$ dotnet run "100 EUR" "rates"
Сумма в исходной валюте: 100,00 EUR
Сумма в USD: 81,97 USD
Сумма в RUB: 8 990,38 RUB
```


## ex01
Simple console task tracker.  

| function | description |
|--|--|
| add | adding a new task |
| list | task list display |
| done | task completed |
| wontdo  | task is not relevant |
| quit | quit program |
### Usage
```
dotnet run
```
### Example
```
$ dotnet run
TaskTracker команды: [ add, list, done, wontdo, quit ]
add
Введите заголовок
- Полить цветы
Введите описание
Не забыть полить цветы
Введите срок
23/03/2022
Введите тип
Personal
Установите приоритет
Medium

- Полить цветы
[Personal] [New]
Priority: Normal
Не забыть полить цветы

list
- Полить цветы
[Personal] [New]
Priority: Normal
Не забыть полить цветы

quit
```

priority - Low, Medium, High.  
type - Work, Study, Personal.
