
# d03
The project works with the Nasa API. The implementation of the connection is moved to separate abstractions.  

The d03.Nasa library is responsible for communication with space and contains client implementations for each of the tasks.

In the d03.Host console application, the configuration is loaded, data is entered and output
## ex00

The program asynchronously accesses the Nasa API and obtains information about the media. The data is parsed from the JSON file into the corresponding object. The result of the query is printed to the console.

### Configuration file
This project requires a config file.  
```
{
   "ApiKey": "YOUR_API_KEY"
}
```
### Usage
```
dotnet run apod {amount}
```
amount - count of media 

### Example
```
$ dotnet run apod 3
2006-09-19
'Beagle Crater on Mars' by
What have we found on the way to large Victoria Crater?  Smaller Beagle Crater.  The robotic Opportunity rover rolling across Mars stopped at Beagle Crater early last month and took an impressively detailed 360-degree panorama of the alien Martian landscape.  Beagle crater appears in the center as a dip exposing relatively dark sand. Surrounding 35-meter Beagle Crater are many of the rocks ejected during its creation impact.  Opportunity's detailed images show significant erosion on the rocks and walls of Beagle Crater, indicating that the crater is not fresh. Beagle Crater's unofficial name derives from the ship HMS Beagle where Charles Darwin observations led him to postulate his theory of natural selection.  That ship was named after the dog breed of beagle.  Opportunity is scheduled to roll up to expansive Victoria Crater this week.
https://apod.nasa.gov/apod/image/0609/beaglecrater_opportunity.jpg

2014-10-28
'Retrograde Mars' by Tunc Tezel
Why would Mars appear to move backwards?  Most of the time, the apparent motion of Mars in Earth's sky is in one direction, slow but steady in front of the far distant stars. About every two years, however, the Earth passes Mars as they orbit around the Sun.  During the most recent such pass starting late last year, Mars as usual, loomed large and bright.  Also during this time, Mars appeared to move backwards in the sky, a phenomenon called retrograde motion.  Featured here is a series of images digitally stacked so that all of the stars coincide.  Here, Mars appears to trace out a narrow loop in the sky.  At the center of the loop, Earth passed Mars and the retrograde motion was the highest.  Retrograde motion can also be seen for other Solar System planets.   APOD Wall Calendar: Moons and Planets
https://apod.nasa.gov/apod/image/1410/RetrogradeMars2014_tezel_1080.jpg

2006-01-01
'The Largest Rock in the Solar System' by
There, that faint dot in the center - that's the largest rock known in our Solar System.  It is larger than every known asteroid, moon, and comet nucleus.  It is larger than any other local rocky planet. (Nobody knows for sure what size rocks lie at the cores of Jovian planets, or orbit other stars.)  It used to be the largest rock of any type known until earlier last year.  The Voyager 1 spacecraft took the above picture of the giant space rock in 1990 from the outer Solar System.  This rock is so large its gravity makes it nearly spherical, and holds heavy gases near its surface. Today, this rock starts another orbit around its parent star, for roughly the 5 billionth time, spinning over 350 times during each trip.  Happy Gregorian Calendar New Year to all the human inhabitants of this rock we call Earth.
https://apod.nasa.gov/apod/image/0601/earth_vg1.jpg
```


## ex01
In this project, an asteroid tracker is presented. The program performs the same actions as in the previous project, but still sorts the result.  

### Configuration file
This project requires a config file.  
```
{
   "ApiKey": "YOUR_API_KEY"
   "NeoWs": {
       "StartDate": "2015-09-07",
       "EndDate": "2015-09-08"
   }   
}
```

### Usage
```
dotnet run neows {amount}
```
amount - count of asteroids 


### Example
```
$ dotnet run neows 3
- Asteroid (2015 RG2), SPK-ID:3726788
Classification: AMO,
Near-Earth asteroid orbits similar to that of 1221 Amor.
Url: http://ssd.jpl.nasa.gov/sbdb.cgi?sstr=3726788


- Asteroid (2015 RC), SPK-ID:3726710
Classification: APO,
Near-Earth asteroid orbits which cross the Earth's orbit similar to that of 1862 Apollo.
Url: http://ssd.jpl.nasa.gov/sbdb.cgi?sstr=3726710


- Asteroid (2015 RO36), SPK-ID:3727181
Classification: APO,
Near-Earth asteroid orbits which cross the Earth's orbit similar to that of 1862 Apollo.
Url: http://ssd.jpl.nasa.gov/sbdb.cgi?sstr=3727181
```
