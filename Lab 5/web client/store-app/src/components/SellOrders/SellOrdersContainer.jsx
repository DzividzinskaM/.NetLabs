import React from 'react';
import * as axios from 'axios';
import {setSellOrders} from './../../redux/sellOrdersReducer'
import { connect } from 'react-redux';
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button'

class SellOrdersApiComponent extends React.Component {
    componentDidMount(){
        debugger;
        axios
        .get("https://localhost:44367/api/sell/orders")
        .then((response) => {
            this.props.setSellOrders(response.data);
        });
    }
    
    render() {
       
        let sellOrders = this.props.sellOrders.map(o => {
            return <tr>
                <td>{o.id}</td>
                <td>{o.date}</td>
                <td>{o.productId}</td>
                <td>{o.number}</td>
                <td>{o.sum}</td>
                <td>{o.customer}</td>
                <td>{!o.isClosed ? "Not closed" : "Closed"}</td>
        </tr>
        });


        return <div>
            <h2>Sell orders</h2>
            <Table size="lg" bordered = {true}  size="md" striped = {true}>
                <thead>
                    <tr>
                    <th>Id</th>
                    <th>Date</th>
                    <th>Product id</th>
                    <th>Number</th>
                    <th>Sum</th>
                    <th>Customer</th>
                    <th>Status</th>
                    </tr>
                </thead>
                <tbody className="bordered">
                    {sellOrders}
                </tbody>
            </Table>
        </div>
    }
}


let mapStateToProps = (state) => {
    return {
        sellOrders: state.SellOrdersPage.sellOrders
    }
}


let SellOrdersContainer = connect(mapStateToProps, {setSellOrders})(SellOrdersApiComponent);

export default SellOrdersContainer;