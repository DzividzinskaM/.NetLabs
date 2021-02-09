import React from 'react';
import * as axios from 'axios';
import { connect } from 'react-redux';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import s from './SellOrder.module.css';
import {Link, NavLink} from 'react-router-dom';
import SellOrdersContainer from './SellOrdersContainer';

class SellOrderFormApiComponent extends React.Component {
    
    constructor(props){
        super(props);

        this.state = {
            customer: "",
            productId: this.props.productId,
            number: 0
        }
    }

    changeHandler = (e) => {
        if(e.target.type === "number")
            this.setState({[e.target.name]: parseInt(e.target.value)});
        else{
            this.setState({[e.target.name]: e.target.value});
        }
    }

    submitHandler = (e) => {
        axios
        .post("https://localhost:44367/api/sell/orders", this.state)
        .then(response =>{
            console.log(response);
        })
        .catch(error => console.log(error));

        
    }

    render() {
        const {customer,productId, number} = this.state;
        return <div> 
            
                <div className = {s.wrapper}>

                <div>Order for product {productId}: Please fill fields</div>
                <Form >
                    <Form.Group >
                        <Form.Label>Customer</Form.Label>
                        <Form.Control type="text" name = "customer" value ={customer} onChange={this.changeHandler} />
                    </Form.Group>
                    <Form.Group >
                        <Form.Label>Number</Form.Label>
                        <Form.Control type="number" name = "number" value ={number} onChange={this.changeHandler} />
                    </Form.Group>


                    <Button variant="outline-primary" onClick = {this.submitHandler}><Link to = "/products" className={s.link}>Submit</Link></Button>
                </Form>


                {/*  <div>Order for product {productId}: Please fill fields</div>
                    <form onSubmit = {this.submitHandler}>
                        <div className="">
                            Customer: <input type="text" name="customer" value={customer} onChange = {this.changeHandler}/>
                        </div>
                        <div className="">
                            Number: <input type="number" name="number" value = {number} onChange = {this.changeHandler}/>
                        </div>
                        <button type="submit">Submit</button>
                    </form> */}
                </div>
            
            </div>

    }
}

let mapStateToProps = (state) => {
    debugger;
    return {
        productId: state.ProductsPage.chosenProductId
    }

}

let SellOrderForm = connect(mapStateToProps, {})(SellOrderFormApiComponent);



export default SellOrderForm;