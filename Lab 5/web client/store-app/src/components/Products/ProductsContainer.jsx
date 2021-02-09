import React from 'react';
import * as axios from 'axios';
import { connect } from 'react-redux';
import {setProducts, chooseProduct} from '../../redux/productsReducer';
import {Link} from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button'
import s from './Products.module.css';


class ProductsApiComponent extends React.Component {

    /* constructor(props){
        super(props);
    }
 */
    componentDidMount() {
        axios
        .get("https://localhost:44367/api/products")
        .then((response) => {
            this.props.setProducts(response.data);
        });
    }

    clickHandler = (productId) => {
        this.props.chooseProduct(productId);
    }

    render() {

        let products = this.props.products.map(p => {
            return <tr>
                <td>{p.productID}</td>
                <td>{p.productName}</td>
                <td>{p.cost}</td>
                <td>{p.number <= 0 
                            ? "not available" 
                            : <div> {p.number}</div>}
                </td>
                <td><Button variant="outline-primary" onClick ={() => this.clickHandler(p.productID)}>
                <Link to= "/orders/sell/create" className={s.link}>Sell</Link>
            </Button>
            <Button variant="outline-primary"  onClick ={() => this.clickHandler(p.productID)}>
                <Link to= "/orders/buy/create" className={s.link}>Buy</Link>
            </Button></td>
          </tr>
        })

        return <div>
            <h2>Products</h2>
            <Table size="lg" bordered = {true}  size="md" striped = {true}>
                <thead>
                    <tr>
                    <th>#</th>
                    <th>Product</th>
                    <th>Cost</th>
                    <th>Number</th>
                    <th>Actions</th>
                    </tr>
                </thead>
                <tbody className="bordered">
                    {products}
                </tbody>
            </Table>
        </div>
    }
}

let mapStateToProps = (state) => {
    return {
        products: state.ProductsPage.products
    };
}

let ProductsContainer = connect(mapStateToProps, {setProducts, chooseProduct})(ProductsApiComponent);

export default ProductsContainer;