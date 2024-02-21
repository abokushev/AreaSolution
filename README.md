# AreaSolution
This library is created to calculate areas of figures. It may calculate areas of:
* Circles;
* Triangles;
* Parallelograms;
* Trapezoids;
* Polygons.

It also provides method to find out if the triangle is right. Some methods are covered with unit tests as examples. 
To calculate areas of more complex shapes I've used the Gaussian area formula for a polygon.

# ProductCategoryQuery
The MS SQL Server database has products and categories. One product can have many categories and one category can have many products. 
Here is an SQL query to select all “Product Name – Category Name” pairs. This query uses a LEFT JOIN to include all products, even those that don't have corresponding categories. The COALESCE function is used to output "Uncategorized" if the product has no categories.
```
SELECT 
    P.ProductName,
    COALESCE(C.CategoryName, 'Uncategorized') AS CategoryName
FROM 
    Products P
LEFT JOIN 
    ProductCategory PC ON P.ProductID = PC.ProductID
LEFT JOIN 
    Categories C ON PC.CategoryID = C.CategoryID;
```

