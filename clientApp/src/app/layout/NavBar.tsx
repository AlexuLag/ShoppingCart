
import { Container, Icon, Menu } from "semantic-ui-react";

export default function navBar(){
return (
    <Menu inverted fixed='top'>
        <Container>
            <Menu.Item header> 
                <Icon  name='cart' />
            </Menu.Item>
        </Container>
    </Menu>
)

}