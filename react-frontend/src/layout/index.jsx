import React from 'react'
import Navbar from '../component/Navbar/Navbar'
import { Outlet } from 'react-router-dom'
import Footer from '../component/Footer/Footer'

const index = () => {
  return (
    <>
    <Navbar/>
    <Outlet/>
    <Footer/>
    </>
  )
}

export default index
