import * as React from 'react';
import {Link} from 'react-router-dom';
import styled from 'styled-components/macro';
import {smallScreen} from "./Variables";

export const Logo: React.FC = () => {
  return (
    <StyledLink to="/">
      <img src='/images/doctorlinklogo.svg' alt={'doctor link logo'}/>
    </StyledLink>
  )
};

const StyledLink = styled(Link)`
  @media only screen and (max-width: ${smallScreen}px) { 
    img {
      max-width: 70px;
    } 
  }
`;


