import React from 'react';
import * as axios from 'axios';
import {setBuyOrders} from './../../redux/buyOrdersReducer';
import { connect } from 'react-redux';
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button'
import { Link } from 'react-router-dom';
import s from './BuyOrder.module.css';

class BuyOrdersApiComponent extends React.Component {

    constructor(props){
        super(props);

        this.state = 
        {
            orderId: 0,
            supplier: ""
        };
    }

    componentDidMount(){
        axios
        .get("https://localhost:44367/api/buy/orders")
        .then((response) => {
            debugger;
            this.props.setBuyOrders(response.data);
        })
    }

    submitHandler = (id) =>{
        //console.log(id);
        if(!this.state.supplier){
            alert("Enter supplier name");
            return;
        }

        debugger;
        axios.put(`https://localhost:44367/api/buy/orders/${id}`, {
            name: this.state.supplier
        })
        .then((response) => {
            console.log(response);
        })
        .catch((error) => {
            console.log(error);
        })
    }

    changeHandler = (e) => {
        this.setState({[e.target.name]: e.target.value});
    }


    render() {
        const {supplier} = this.state;

        let buyOrders = this.props.buyOrders.map(o => {
            return <tr>
                <td>{o.id}</td>
                <td>{o.date}</td>
                <td>{o.productId}</td>
                <td>{o.number}</td>
                <td>{o.sum}</td>
                <td>{o.supplierName 
                        ? o.supplierName
                        : <form >
                            <input type="text" name="supplier" value={supplier} onChange = {this.changeHandler}/>
                         </form>
                    }</td>
                <td>{ o.supplierName 
                        ? "Closed"
                        : <Button variant="outline-primary" onClick={() => {this.submitHandler(o.id)}}>
                                <Link to="/products" className={s.link}>Submit</Link>
                            </Button> 
                    }</td>
        </tr>
        });
    
    
        return <div>
            <div>
            <h2>Buy orders</h2>
            <Table size="lg" bordered = {true}  size="md" striped = {true}>
                <thead>
                    <tr>
                    <th>Id</th>
                    <th>Date</th>
                    <th>Product id</th>
                    <th>Number</th>
                    <th>Sum</th>
                    <th>Supplier</th>
                    <th>Status</th>
                    </tr>
                </thead>
                <tbody className="bordered">
                    {buyOrders}
                </tbody>
            </Table>
        </div>
        </div>
    }
}

let mapStateToProps = (state) => {
    return {
        buyOrders: state.BuyOrdersPage.buyOrders
    }
}

let BuyOrdersContainer = connect(mapStateToProps, {setBuyOrders})(BuyOrdersApiComponent);

export default BuyOrdersContainer;