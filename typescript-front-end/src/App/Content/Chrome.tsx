import * as React from 'react';
import styled from 'styled-components/macro';
import {smallScreen} from '../Variables';

interface Props {
  children?: React.ReactNode;
}

export const Chrome: React.FC<Props> = ({children}) => {
  return (
    <Host>
      <Header>
        <StyledNHSLogo src='/images/NHSLogo.svg' alt={'doctor link logo'}/>
      </Header>
      <ChildrenHost>
        {children}
      </ChildrenHost>
    </Host>
  )
};


const Host = styled.div`
  display: flex;
  flex-flow: column;
  flex: 1 1 auto;
`;

const ChildrenHost = styled.div`
  display: flex;
  flex-flow: column;
  justify-content: center;
  align-items: center;
  margin: 0 auto;
  padding-bottom: 350px;
  text-align: center;
  @media only screen and (max-width: ${smallScreen}px) {  
    padding-bottom: 0;
  }
`;

const Header = styled.div`
  display: flex;
  align-items: flex-end;
  flex-flow: column;
  margin: 5px;
`

const StyledNHSLogo = styled.img`
  max-width: 100px;
  float:right;
`;


