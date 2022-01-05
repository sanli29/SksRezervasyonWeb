import React from 'react'
import { useSelector, useDispatch } from 'react-redux'
import { CButton, CSidebar, CSidebarBrand, CSidebarNav, CSidebarToggler } from '@coreui/react'
import { AppSidebarNav } from './AppSidebarNav'
import SimpleBar from 'simplebar-react'
import 'simplebar/dist/simplebar.min.css'
// sidebar nav config
import ogrenciNavigation from '../_ogrenciNav'
import { Link } from 'react-router-dom'

const AppSidebar = ({ role }) => {
  const dispatch = useDispatch()
  const unfoldable = useSelector((state) => state.sidebarUnfoldable)
  const sidebarShow = useSelector((state) => state.sidebarShow)
  let navbar

  if (role === 'ogrenci') {
    navbar = <AppSidebarNav items={ogrenciNavigation} />
  }
  return (
    <CSidebar
      position="fixed"
      unfoldable={unfoldable}
      visible={sidebarShow}
      onVisibleChange={(visible) => {
        dispatch({ type: 'set', sidebarShow: visible })
      }}
    >
      <CSidebarBrand className="d-none d-md-flex" to="/">
        <Link style={{ textDecoration: 'none' }} to="/ogrenci/Homepage">
          <h5 style={{ color: 'white' }}>Bakırçay Üniversitesi</h5>
        </Link>
      </CSidebarBrand>
      <CSidebarNav>
        <SimpleBar>{navbar}</SimpleBar>
      </CSidebarNav>
      <CSidebarToggler
        className="d-none d-lg-flex"
        onClick={() => dispatch({ type: 'set', sidebarUnfoldable: !unfoldable })}
      />
    </CSidebar>
  )
}

export default React.memo(AppSidebar)
