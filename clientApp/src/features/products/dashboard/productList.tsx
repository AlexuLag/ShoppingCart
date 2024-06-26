import { Fragment } from 'react/jsx-runtime'
import { useStore } from '../../../app/stores/store';
import { observer } from 'mobx-react-lite';
import ProductItem from './productItem';



export default observer(function ProductList() {

    const { productStore } = useStore();
    const { products } = productStore;
    
    return (
        <Fragment>
            {products.map((product) => (
                <ProductItem key={product.id} product={product} />
            ))}
        </Fragment>
    )
})
