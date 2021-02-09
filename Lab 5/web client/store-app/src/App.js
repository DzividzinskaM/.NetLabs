import './App.css';
import Navigation from './components/Navigation/Navigation';
import { Route } from 'react-router-dom';
import SellOrdersContainer from './components/SellOrders/SellOrdersContainer';
import BuyOrdersContainer from './components/BuyOrders/BuyOrdersContainer';
import AddProductForm from './components/Products/AddProductForm';
import SellOrderForm from './components/SellOrders/SellOrderForm';
import BuyOrderForm from './components/BuyOrders/BuyOrderForm';
import ProductsContainer from './components/Products/ProductsContainer';




function App() {
  return (
    <div>
      <Navigation />  
      <Route exact strict path = '/products/add'
              component = {() => <AddProductForm />} />
      <Route exact strict path='/products'
                render = {() =><ProductsContainer/> } />
      <Route exact strict  path = '/orders/sell'
              render = {() => <SellOrdersContainer/>} />
      <Route exact strict  strict path = '/orders/buy'
              render = {() => <BuyOrdersContainer/>} />
      <Route exact strict path = '/orders/sell/create'
              render = {() => <SellOrderForm />} />
      <Route exact strict path = '/orders/buy/create'
              render = {() => <BuyOrderForm/>} />
    </div>
  );
}

export default App;
