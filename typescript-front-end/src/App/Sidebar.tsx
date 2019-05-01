import * as React from 'react';
import styled from 'styled-components/macro';

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
`;

const Header = styled.div`
  display: flex;
`

const Menu = styled.div`
  display: flex;
  flex-flow: column;
  flex: 1 1 100%;
  justify-content: center;
`

