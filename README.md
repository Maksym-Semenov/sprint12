# Task

Create an ASP.Net Core MVC application which performs appropriate calculations for triangles.
Design all classes and methods in your own way.
The application should handle the following requests: 

1. Show the info about a triangle in a form as follows:
```
------------------------------------------------------------
Triangle:
([side_1], [side_2], [side_3])
Reduced:
([side_1/perimeter], [side_2/perimeter], [side_3/perimeter])

Area = XX
Perimeter = YY
------------------------------------------------------------
```
Here `[side_1], [side_2], [side_3]` are `[side1], [side2], [side3]` arranged in ascending order.
```
[hostname]/triangle/Info?side1=10&side2=20&side3=25
```



2. Calculate the area of a triangle
```
[hostname]/triangle/Area?side1=10&side2=20&side3=25
94.9922
```

3. Calculate the perimeter of a triangle
```
[hostname]/triangle/Perimeter?side1=10&side2=20&side3=25
55
```

4. Return True or False depending on the triangle is right-angled or not 
```
[hostname]/triangle/IsRightAngled?side1=3&side2=5&side3=4
true
[hostname]/triangle/IsRightAngled?side1=3&side2=5&side3=6
false
```

5. Return True or False depending on the triangle is equilateral or not 
```
[hostname]/triangle/IsEquilateral?side1=10&side2=10&side3=10
true
[hostname]/triangle/IsEquilateral?side1=10&side2=12&side3=10
false
```

6. Return True or False depending on the triangle is isosceles or not 
```
[hostname]/triangle/IsIsosceles?side1=15&side2=20&side3=15
true
[hostname]/triangle/IsIsosceles?side1=16&side2=20&side3=15
false
```

7. Return True or False depending on two triangles are congruent or not
```
[hostname]/triangle/arecongruent?tr1.side1=10&tr1.side2=20&tr1.side3=15&tr2.side1=15&tr2.side2=10&tr2.side3=20
true
[hostname]/triangle/arecongruent?tr1.side1=10&tr1.side2=20&tr1.side3=15&tr2.side1=15&tr2.side2=12&tr2.side3=20
false
```

8. Return True or False depending on two triangles are similar or not
```
[hostname]/triangle/aresimilar?tr1.side1=10&tr1.side2=20&tr1.side3=15&tr2.side1=30&tr2.side2=20&tr2.side3=40
true
[hostname]/triangle/aresimilar?tr1.side1=10&tr1.side2=20&tr1.side3=15&tr2.side1=15&tr2.side2=12&tr2.side3=20
false
```

9. Return the info about the triangle with greatest perimeter (given the array of triangles)
```
[hostname]/triangle/GreatesByPerimeter?tr[0].side1=10&tr[0].side2=20&tr[0].side3=12&tr[1].side1=10&tr[1].side2=20&tr[1].side3=25&tr[2].side1=10&tr[2].side2=18&tr[2].side3=22
```

10. Return the info about the triangle with greatest area (given the array of triangles)
```
[hostname]/triangle/GreatestByArea?tr[0].side1=10&tr[0].side2=20&tr[0].side3=12&tr[1].side1=10&tr[1].side2=20&tr[1].side3=25&tr[2].side1=10&tr[2].side2=18&tr[2].side3=22
```

11. Return the info about the triangles chosen from the given array which are pairwise non-similar
```
[hostname]/triangle/PairwiseNonSimilar?tr[0].side1=10&tr[0].side2=20&tr[0].side3=12&tr[1].side1=10&tr[1].side2=20&tr[1].side3=25&tr[2].side1=10&tr[2].side2=18&tr[2].side3=22
```

Each request should return an error page in case if the triangle is invalid (e.g. (10, 20, 100))
Equality of values of double type is considered as their difference in less than 0.001 percent of first of them.

