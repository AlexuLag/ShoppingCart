
import { NavLink } from "react-router-dom";
import { Container, Icon, Label, Menu } from "semantic-ui-react";
import { useStore } from "../stores/store";
import { observer } from "mobx-react-lite";

export default observer(function navBar(){

    const { cartStore } = useStore();

    const { totalProducts } = cartStore;
  

return (
    <Menu  fixed='top'>
        <Container>
        <Menu.Item as= {NavLink} to='/' header> 
                 
                ShoppingCart
            </Menu.Item>
            <Menu.Item as= {NavLink} to='/products'  name='Home'>
            <Icon  name='home' />
            </Menu.Item>
            <Menu.Item header as={NavLink} to  ='/cart'>            
                <Icon  name='cart' />
                {
                totalProducts>0  &&  <Label circular color='red' key='a' size='tiny'>
                                         {totalProducts}  
                                    </Label>

                }
               
            </Menu.Item>
        </Container>
    </Menu>
)

})