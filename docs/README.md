<h2>About OrderManagementApi</h2>

OrderManagementAPI was developed to manage customer orders. Created Order Management API
It is used to create, modify, delete and view. Developed with the EF Core generic repository model. MSSQL 2019 database and ElasticSearch are used. All of these can be run with container in Docker.


<h2>To run Application</h2>

Navigate to root of the project and run commands listed below
<li>docker compose build</li>
<li>docker compose up</li>

<h2>HTTP Methods</h2>

The application will be available on <a href="http://localhost:5001/swagger">localhost:5001</a><br>

<h3>Order</h3>

<b>GET Order/{id}</b><br>
<b>POST Order</b><br>
<b>PUT Order/{id}</b><br>
<b>DELETE Order/{id}</b><br>

<h3>Customer</h3>

<b>GET Customer/{id}</b><br>
<b>POST Customer</b><br>
<b>PUT Customer/{id}</b><br>
<b>DELETE Customer/{id}</b><br>

<h3>Product</h3>

<b>GET Product/{id}</b><br>
<b>GET Product/search/{searchText}</b><br>
<b>POST Product</b><br>
<b>PUT Product/{id}</b><br>
<b>DELETE Product/{id}</b><br>