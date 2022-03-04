## ex00

The program parses a JSON file with movie data, converts it and sorts it.  
According to the prepared data, the title of the film of interest is searched.
### Usage
```
dotnet run
```

### Example
```
$ dotnet run
> Input search text:
ar
Items found: 6
Book search result [3]
- THE MIDNIGHT LIBRARY by Matt Haig [6 on NYT's Hardcover Fiction]
Nora Seed finds a library beyond the edge of the universe that contains books with multiple possibilities of the lives one could have lived.
https://www.amazon.com/dp/0525559477?tag=NYTBSREV-20

- THE INVISIBLE LIFE OF ADDIE LARUE by V.E. Schwab [9 on NYT's Hardcover Fiction]
A Faustian bargain comes with a curse that affects the adventure Addie LaRue has across centuries.
https://www.amazon.com/dp/0765387565?tag=NYTBSREV-20

- KLARA AND THE SUN by Kazuo Ishiguro [13 on NYT's Hardcover Fiction]
An "Artificial Friend" named Klara is purchased to serve as a companion to an ailing 14-year-old girl.
https://www.amazon.com/dp/059331817X?tag=NYTBSREV-20

Movie search result [3]
- In Our Mothers' Gardens
The Netflix documentary sets out to show how maternal lineages have shaped generations of Black women.


- Marighella [NYT critic's pick]
Wagner Moura's provocative feature debut chronicles the armed struggle led by Carlos Marighella against Brazil's military dictatorship in the 1960s.


- Things Heard & Seen
Amanda Seyfried and James Norton move into a haunted house in this busy, creaky Netflix thriller.
```


## ex01
Parsing two configurations JSON and YAML in priority order.  

### Usage
```
dotnet run “{jsonPath}” {jsonPriority} “{yamlPath}” {yamlPriority}
```

### Example
```
$ dotnet run "config.json" 1 "config.yml 2"
Configuration
Source: YAML
Application: ex01
CheckForUpdates: false
Port: 8080
Domain: http://localhost


$ dotnet run "config.json" 2 "config.yml" 1
Configuration
Application: ex01
CheckForUpdates: True
Domain: http://localhost
Port: 1234
Source: JSON
```
