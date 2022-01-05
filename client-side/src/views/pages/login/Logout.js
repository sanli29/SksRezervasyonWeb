import React from 'react'
import { Redirect } from 'react-router'
import api from '../../../components/Api/Api'

export default function Logout() {
  let res = api.api().post('ogrenci/Logout', {})
  return <Redirect to="/Login" />
}
