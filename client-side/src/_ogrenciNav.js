import React from 'react'
import CIcon from '@coreui/icons-react'
import { cilAccountLogout, cilStar, cilHistory, cilPhone } from '@coreui/icons'
import { CNavGroup, CNavItem } from '@coreui/react'

const _ogrenciNav = [
  {
    component: CNavGroup,
    name: 'Rezervasyon Yap',
    to: '/ogrenci/HomePage',
    icon: <CIcon icon={cilStar} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Yemekhane',
        to: '/ogrenci/Yemekhane',
      },
      {
        component: CNavItem,
        name: 'Kütüphane',
        to: '/ogrenci/Kutuphane',
      },
      {
        component: CNavItem,
        name: 'Misafirhane',
        to: '/ogrenci/Misafirhane',
      },
      {
        component: CNavItem,
        name: 'Spor Tesisleri',
        to: '/ogrenci/SporTesisleri',
      },
    ],
  },
  {
    component: CNavGroup,
    name: 'Rezervasyonlarım',
    to: '/ogrenci/HomePage',
    icon: <CIcon icon={cilHistory} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Yemekhane',
        to: '/ogrenci/YemekhaneHistory',
      },
      {
        component: CNavItem,
        name: 'Kütüphane',
        to: '/ogrenci/KutuphaneHistory',
      },
      {
        component: CNavItem,
        name: 'Misafirhane',
        to: '/ogrenci/MisafirhaneHistory',
      },
      {
        component: CNavItem,
        name: 'Spor Tesisleri',
        to: '/ogrenci/SporTesisleriHistory',
      },
    ],
  },
  {
    icon: <CIcon icon={cilPhone} customClassName="nav-icon" />,
    component: CNavItem,
    name: 'İletişim',
    to: '/ogrenci/Iletisim',
  },
  {
    icon: <CIcon icon={cilAccountLogout} customClassName="nav-icon" />,
    component: CNavItem,
    name: 'Çıkış Yap',
    to: '/ogrenci/Logout',
  },
]

export default _ogrenciNav
