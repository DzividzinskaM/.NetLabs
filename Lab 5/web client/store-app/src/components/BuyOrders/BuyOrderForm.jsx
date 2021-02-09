import React from 'react';
import * as axios from 'axios';
import { connect } from 'react-redux';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import s from './BuyOrder.module.css';
import { Link } from 'react-router-dom';

class BuyOrderFormApiComponent extends React.Component {
    constructor(props){
        super(props);

        this.state = {
            productId: this.props.productId,
            number: 0
        }
    }

    changeHandler = (e) => {
        this.setState({[e.target.name]: parseInt(e.target.value)});
    }

    submitHandler = () => {
        axios
        .post("https://localhost:44367/api/buy/orders", this.state)
        .then(response =>{
            console.log(response);
        })
        .catch(error => console.log(error));
    }

    render() {
        const {productId, number} = this.state;

        return <div className = {s.wrapper}>
        
        <h2>Buy order for product {this.props.productId}</h2>

        <Form >
            <Form.Group >
                <Form.Label>Number</Form.Label>
                <Form.Control type="number" name = "number" value ={number} onChange={this.changeHandler} />
            </Form.Group>

            <Button variant="outline-primary" onClick={this.submitHandler}>
                <Link to="/orders/buy" className={s.link}>Submit</Link>
            </Button>
        </Form>


            
            {/* <form onSubmit={this.submitHandler}>
                Number: <input type="number" name="number" value= {number} onChange = {this.changeHandler}/>
                <button type = "submit">Send</button>
            </form> */}
        </div>
    }
}

let mapStateToProps = (state) => {
    return {
        productId: state.ProductsPage.chosenProductId
    }

}

let BuyOrderForm = connect(mapStateToProps, {})(BuyOrderFormApiComponent);


export default BuyOrderForm;