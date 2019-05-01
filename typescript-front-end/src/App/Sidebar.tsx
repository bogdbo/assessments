import * as React from 'react';
import styled from 'styled-components/macro';
import {smallScreen} from "./Variables";

interface Props {
  header?: any;
  children?: React.ReactNode;
  className?: string;
}

export const Sidebar: React.FC<Props> = ({header, children, className}) => {
  return (
    <Host className={className}>
      <Header>
        {header}
      </Header>
      <Menu>
        {children}
      </Menu>
    </Host>
  )
};

const Host = styled.div`
  display: flex;
  flex-flow: column;
  flex: 1 1 100%;
  max-width: 300px;
  background: #fbfbfb;
  padding: 20px;
  border-right: 2px solid #eee;
  
  @media only screen and (max-width: ${smallScreen}px) {
    flex-direction: row;
    max-width: 100%;
    border-right: none;
    border-bottom: 2px solid #eee;
    padding: 5px;
    flex: 0;
  }
`;

const Header = styled.div`
  display: flex;
  @media only screen and (max-width: ${smallScreen}px) { 
    flex-direction: column; 
    justify-content: center;
  }
`

const Menu = styled.div`
  display: flex;
  flex-flow: column;
  flex: 1 1 100%;
  justify-content: center;
  
  @media only screen and (max-width: ${smallScreen}px) {
    flex-direction: row;
    justify-content: flex-start;
    align-items: center;
  }
`

