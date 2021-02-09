import {combineReducers, createStore} from 'redux';
import productsReducer from './productsReducer';
import sellOrdersReducer from './sellOrdersReducer';
import buyOrdersReducer from './buyOrdersReducer';


let reducers = combineReducers({
    ProductsPage: productsReducer,
    SellOrdersPage: sellOrdersReducer,
    BuyOrdersPage: buyOrdersReducer
});

let store = createStore(reducers);

export default store;

