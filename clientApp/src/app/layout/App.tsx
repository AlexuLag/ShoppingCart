
import { Fragment, useEffect, useState } from 'react'

import { Button, Container, Icon, Item, Label, Segment  } from 'semantic-ui-react';
import { Product } from '../models/product';
import NavBar from './NavBar';
import agent from '../api/agent';

function App() {

  const [products, setProducts] = useState<Product[]>([]);




  useEffect(() => {
   agent.Products.list().then(response => {
      setProducts(response.data)
    })
  }, []);




  function increment(product: Product) {

    const updatedProducts = products.map(item => {
      if (item.id === product.id  && item.stock>item.quantity) {
        return { ...item, quantity: item.quantity + 1 };
      }
      return item;
    });

    setProducts(updatedProducts);
  }



  function decrement(product: Product) {
    const updatedProducts = products.map(item => {
      if (item.id === product.id && item.quantity > 0) {
        return { ...item, quantity: item.quantity - 1 };
      }
      return item;
    });

    setProducts(updatedProducts);
  }


  return (
    <div>
      <NavBar />
      <Fragment>
        <Container style={{ marginTop: '7em' }}>


          {products.map((product) => (

            <Segment.Group key={product.id}>
              <Segment >
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
                        Quantity: {product.stock}
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
                <Button icon size='mini' onClick={() => decrement(product)} >
                  <Icon name='minus' />
                </Button>
                <Label>
                  {product.quantity ?? 0}
                </Label>
                <Button icon size='mini' onClick={() => increment(product)} >
                  <Icon name='add' />
                </Button>
              </Segment>

            </Segment.Group>


          ))}


        </Container>
      </Fragment>

    </div>


  )
}

export default App
