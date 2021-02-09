const SET_PRODUCTS = "SET_PRODUCTS";
const CHOOSE_PRODUCT_ID = "CHOOSE_PRODUCT_ID";


let initialState = {
    products: [], 
    chosenProductId: 0
}

let productsReducer = (state = initialState, action) =>{
    switch (action.type) {
        case SET_PRODUCTS: {
            return {
                ...state,
                products: [...action.products]
            };
        }
        case CHOOSE_PRODUCT_ID: {
            return {
                ...state,
                chosenProductId: action.chosenProductId
            }
        }
        default:
            return state;
    }
}

export const setProducts = (products) => ({type: SET_PRODUCTS, products});
export const chooseProduct = (chosenProductId) => ({type: CHOOSE_PRODUCT_ID, chosenProductId});

export default productsReducer;