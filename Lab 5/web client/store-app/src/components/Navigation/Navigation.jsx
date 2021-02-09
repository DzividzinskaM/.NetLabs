import React from 'react'
import { NavLink } from 'react-router-dom';
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav'
import 'bootstrap/dist/css/bootstrap.min.css';


let Navigation = () =>{
    return <Navbar bg="dark" variant="dark">
    <Nav className="mr-auto">
      <Nav.Link href="/products">Products</Nav.Link>
      <Nav.Link href="/products/add">Add new product</Nav.Link>
      <Nav.Link href="/orders/buy">Buy orders</Nav.Link>
      <Nav.Link href="/orders/sell">Sell orders</Nav.Link>
    </Nav>
    
  </Navbar>
    
/*     <nav>
        <li><NavLink to= "/products">Products</NavLink></li>
        <li><NavLink to= "/orders/buy">Buy orders</NavLink></li>
        <li><NavLink to= "/orders/sell">Sell orders</NavLink></li>
    </nav> */
}

export default Navigation;