import { Fragment } from 'react/jsx-runtime'
import { Button, Icon, Item, Label, Segment } from 'semantic-ui-react'
import { useStore } from '../../../app/stores/store';
import { observer } from 'mobx-react-lite';


export default   observer(function productList() {


    const { productStore,cartStore } = useStore();
    const { products } = productStore;

    

    


    return (
        <Fragment>
         
          {products.map((product) => (
                    <Segment.Group  >
                        <Segment  >
                            <Item.Group>
                                <Item>
                                    <Item.Image size='tiny' src={product.imageUrl} />
                                    <Item.Content>
                                        <Item.Header>
                                            {product.name}
                                        </Item.Header>
                                        <Item.Description>
                                            Code: {product.code}
                                        </Item.Description>
                                        <Item.Description>
                                            Description: {product.description}
                                        </Item.Description>
                                        <Item.Meta>
                                            Stock: {product.stock}
                                        </Item.Meta>
                                        <Item.Meta>
                                            Price: <Label as='a' color='green' tag>$ {product.unitPrice}</Label>
                                        </Item.Meta>
                                        <Item.Extra>
                                            {
                                                product.categories.map((category) => (
                                                    <Label as='a' color='grey' size='tiny'>
                                                        {category.name}
                                                    </Label>
                                                ))
                                            }
                                        </Item.Extra>
                                    </Item.Content>
                                </Item>
                            </Item.Group>
                        </Segment>
                        <Segment secondary  >
                      
                            <Button icon size='mini' onClick={ () =>
                                 product.quantity = product.quantity<1 ? 0 : product.quantity-1
                                 
                                 }>
                                <Icon name='minus' />
                            </Button>

                          
                            
                            <Button icon size='mini'  onClick={ () => 
                                    product.quantity =product.stock> product.quantity ? product.quantity +1:product.quantity 
                                    }  >
                                <Icon name='add' />
                            </Button>
                            
                            <Button
                                content='Add to cart '
                                icon='cart'
                                size='mini'
                                color='blue'
                                label={product.quantity ?? 0}
                                labelPosition='left'
                                onClick={ ()=> cartStore.addProductToCart(product,product.quantity) }
                               
                                />

                            
                        </Segment>
              

                    </Segment.Group>
                    


                ))}
    
          

        </Fragment>



    )
})
