import React from 'react';
import styled from 'styled-components/macro';
import {Sidebar} from './App/Sidebar';
import {Logo} from "./App/AppLogo";
import {Link, Route, Switch} from "react-router-dom";
import {Homepage} from "./App/Content/Homepage";
import {Notifications} from "./App/Content/Notifications/Notifications";

class App extends React.Component<{}, {}> {
  render() {
    return (
      <Host>
        <StyledSidebar header={<Logo/>}>
          <StyledLink to={'/'}>Homepage</StyledLink>
          <StyledLink to={'/notifications'}>Notifications</StyledLink>
        </StyledSidebar>

        <Switch>
          <Route path={'/'} exact={true} component={Homepage} />
          <Route path={'/notifications'} component={Notifications} />
        </Switch>
      </Host>
    );
  }
}

export default App;

const Host = styled.div`
  display: flex; 
  flex: 1 1 auto;
  height: 100%;
`;

const StyledLink = styled(Link)`
  text-decoration: none;
  padding: 10px 0;
  font-size: 24px;
  color: black;
`

const StyledSidebar = styled(Sidebar)`
`
