const SET_BUY_ORDERS = "SET_BUY_ORDERS";


let initialState = {
    buyOrders: []
}

let buyOrdersReducer = (state = initialState, action) =>{
    switch (action.type) {
        case SET_BUY_ORDERS: {
            debugger;
            return {
                ...state,
                buyOrders: [...action.buyOrders]
            };
        }
        default:
            return state;
    }
}

export const setBuyOrders = (buyOrders) => ({type: SET_BUY_ORDERS, buyOrders});

export default buyOrdersReducer;