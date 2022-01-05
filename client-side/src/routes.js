import React from 'react'
const HomePage = React.lazy(() => import('./views/pages/homePage/HomePage'))
const Yemekhane = React.lazy(() => import('./views/pages/rezervasyonYap/Yemekhane'))
const Kutuphane = React.lazy(() => import('./views/pages/rezervasyonYap/Kutuphane'))
const Misafirhane = React.lazy(() => import('./views/pages/rezervasyonYap/Misafirhane'))
const SporTesisleri = React.lazy(() => import('./views/pages/rezervasyonYap/SporTesisleri'))
const Iletisim = React.lazy(() => import('./views/pages/iletisim/Iletisim'))
const Logout = React.lazy(() => import('./views/pages/login/Logout'))
const KutuphaneHistory = React.lazy(() =>
  import('./views/pages/rezervasyonlarim/KutuphaneRezervasyonlarim'),
)
const MisafirhaneHistory = React.lazy(() =>
  import('./views/pages/rezervasyonlarim/MisafirhaneRezervasyonlarim'),
)
const SporTesisleriHistory = React.lazy(() =>
  import('./views/pages/rezervasyonlarim/SporTesisleriRezervasyonlarim'),
)
const YemekhaneHistory = React.lazy(() =>
  import('./views/pages/rezervasyonlarim/YemekhaneRezervasyonlarim'),
)

const routes = [
  {
    path: '/ogrenci/HomePage',
    name: 'HomePage',
    component: HomePage,
    exact: true,
    props: { role: 'ogrenci' },
  },

  {
    path: '/ogrenci/Yemekhane',
    name: 'Yemekhane',
    component: Yemekhane,
    exact: true,
    props: { role: 'ogrenci' },
  },

  {
    path: '/ogrenci/Kutuphane',
    name: 'Kütüphane',
    component: Kutuphane,
    exact: true,
    props: { role: 'ogrenci' },
  },

  {
    path: '/ogrenci/Misafirhane',
    name: 'Misafirhane',
    component: Misafirhane,
    exact: true,
    props: { role: 'ogrenci' },
  },

  {
    path: '/ogrenci/SporTesisleri',
    name: 'SporTesisleri',
    component: SporTesisleri,
    exact: true,
    props: { role: 'ogrenci' },
  },

  {
    path: '/ogrenci/SporTesisleriHistory',
    name: 'SporTesisleriHistory',
    component: SporTesisleriHistory,
    exact: true,
    props: { role: 'ogrenci' },
  },

  {
    path: '/ogrenci/MisafirhaneHistory',
    name: 'MisafirhaneHistory',
    component: MisafirhaneHistory,
    exact: true,
    props: { role: 'ogrenci' },
  },

  {
    path: '/ogrenci/KutuphaneHistory',
    name: 'KutuphaneHistory',
    component: KutuphaneHistory,
    exact: true,
    props: { role: 'ogrenci' },
  },

  {
    path: '/ogrenci/YemekhaneHistory',
    name: 'YemekhaneHistory',
    component: YemekhaneHistory,
    exact: true,
    props: { role: 'ogrenci' },
  },

  {
    path: '/ogrenci/Iletisim',
    name: 'Iletisim',
    component: Iletisim,
    exact: true,
    props: { role: 'ogrenci' },
  },

  {
    path: '/ogrenci/Logout',
    name: 'Logout',
    component: Logout,
    exact: true,
  },
]

export default routes
