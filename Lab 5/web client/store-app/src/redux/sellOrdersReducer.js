const SET_SELL_ORDERS = "SET_SELL_ORDERS"

let initialState = {
    sellOrders: []
}

let sellOrdersReducer = (state = initialState, action) =>{
    switch (action.type) {
        case SET_SELL_ORDERS:
            return {
                ...state,
                sellOrders: [...action.sellOrders]
            }
        default:
            return state;
    }
};

export const setSellOrders = (sellOrders) => ({type: SET_SELL_ORDERS, sellOrders});

export default sellOrdersReducer;