import * as React from 'react';
import styled from "styled-components";
import {Link} from "react-router-dom";
import {Chrome} from "./Chrome";

export const Homepage: React.FC = () => {
  return (
    <Chrome>
      <StyledBanner src={'/images/Main_Illustration.png'} alt={'homepage banner'}/>
      <h1>Welcome to Doctorlink</h1>
      <ViewNotifications to={'/notifications'}>View notifications</ViewNotifications>
    </Chrome>
  )
};

const StyledBanner = styled.img`
  max-width: 60%;
`

const ViewNotifications = styled(Link)`
  margin: 0 auto;
  font-weight: bold;
  text-decoration: none;
  max-width: 150px;
  background-color: #2716ad;
  border-radius: 28px;
  border: 1px solid #3928bf;
  display: inline-block;
  cursor: pointer;
  color: #ffffff;
  font-size: 17px;
  padding: 16px 31px;
  text-shadow: 0px 1px 0px #2f6627;
    
  &:hover {
    background-color:#3928bf;
  }
  
  &:active {
    position:relative;
    top:1px;
  }
`;

