import * as axios from 'axios';
import React from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import s from './Products.module.css';
import {Link} from 'react-router-dom';


class AddProductsForm extends React.Component{
    constructor(props){
        super(props)

        this.state = {
            productName: '',
            cost: 0,
            number: 0
        }
    }

    changeHandler = (e) => {
        if(e.target.name === "cost" || e.target.name === "number"){
            this.setState({[e.target.name]: parseInt(e.target.value)})
        }
            else{
            this.setState({[e.target.name]: e.target.value})
        }
        
    }

    submitHandler = (e) =>{
        e.preventDefault();
        console.log(this.state)
        axios
        .post("https://localhost:44367/api/products", this.state)
        .then((response)=>{
            console.log(response);
        })
        .catch(error => {
            console.log("error");
        })
    }

    render(){
        const {productName, cost, number} = this.state
        return <div className = {s.wrapper}>


        <Form className = {s.form}>
        <Form.Group >
            <Form.Label>Name</Form.Label>
            <Form.Control type="text" name = "productName" value={productName} onChange={this.changeHandler} />
        </Form.Group>
        <Form.Group >
            <Form.Label>Cost</Form.Label>
            <Form.Control type="number" name = "cost" value ={cost} onChange={this.changeHandler} />
        </Form.Group>
        <Form.Group >
            <Form.Label>Number</Form.Label>
            <Form.Control type="number" name = "number" value ={number} onChange={this.changeHandler} />
        </Form.Group>

        <Button variant="outline-primary" type="submit"  onClick={this.submitHandler}>
            <Link to = "/products"  className = {s.link}>
            Submit
            </Link>
        </Button>
       

        </Form>



           {/*  <form onSubmit={this.submitHandler}>
                <div className="">
                    Name: <input type="text" name = "productName" value={productName} onChange={this.changeHandler}/>
                </div>
                <div className="">
                    Cost: <input type="number" name = "cost" value ={cost} onChange={this.changeHandler}/>
                </div>
                <div className="">
                    Number: <input type="number" name = "number" value = {number} onChange={this.changeHandler}/>
                </div>
                <button type="submit">Submit</button>
            </form> */}
        </div>
    }
}

export default AddProductsForm;