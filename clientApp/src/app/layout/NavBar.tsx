
import { Link, NavLink } from "react-router-dom";
import { Container, Dropdown, Icon, Label, Menu, Image } from "semantic-ui-react";
import { useStore } from "../stores/store";
import { observer } from "mobx-react-lite";

export default observer(function navBar() {

    const { cartStore } = useStore();

    const { totalProducts,user } = cartStore;


    return (
        <Menu fixed='top'>
            <Container>
                <Menu.Item as={NavLink} to='/' header>

                    ShoppingCart
                </Menu.Item>
                <Menu.Item as={NavLink} to='/products' name='Home'>
                    <Icon name='product hunt' />
                    Products
                </Menu.Item>
                <Menu.Item header as={NavLink} to='/cart'>

                    <Icon name='cart' />
                    Cart
                    {
                        totalProducts > 0 && <Label circular color='red' key='a' size='tiny'>
                            {totalProducts}
                        </Label>

                    }

                </Menu.Item>

                <Menu.Item header as={NavLink} to='/orders'>
                    <Icon name='truck' />
                    Orders

                </Menu.Item>
                <Menu.Item position='right'>
                    <Image avatar spaced='right' src={'/assets/UserIcon.png'} />
                     Welcome! {user?.firstName}
                </Menu.Item>
            </Container>
        </Menu>
    )

})