# AreaSolution
This library is created to calculate areas of figures. It may calculate areas of:
*Circles;
*Triangles;
*Parallelograms;
*Trapezoids;
It also provides method to find out if the triangle is right. All methods are covered with unit tests. 
To calculate areas of more complex shapes I'd use Cartesian coordinate system with coordinates of vertices and functions to describe sides. 
Calculating definite integrals of this functions will let us calculate area of any shape.

# ProductCategoryQuery
The MS SQL Server database has products and categories. One product can have many categories and one category can have many products. 
Here is an SQL query to select all “Product Name – Category Name” pairs. If a product has no categories its name should still be displayed.
```
SELECT Products.Name, Category.Name
FROM Products LEFT JOIN  Category ON Products.Id=Category.productId 
ORDER BY Products.Name;
```

