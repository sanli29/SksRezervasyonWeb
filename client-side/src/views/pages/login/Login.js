import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import {
  CButton,
  CCard,
  CCardBody,
  CCardGroup,
  CCol,
  CContainer,
  CForm,
  CFormInput,
  CInputGroup,
  CInputGroupText,
  CRow,
} from '@coreui/react'
import CIcon from '@coreui/icons-react'
import { cilLockLocked, cilUser } from '@coreui/icons'
import Alert from '../../../components/Alert/Alert'
import { Redirect } from 'react-router'
import api from '../../../components/Api/Api'

const Login = () => {
  const [email, setEmail] = useState('emre@gmail.com')
  const [password, setPassword] = useState('naber')
  const [role, setRole] = useState('ogrenci')
  const [redirect, setRedirect] = useState(false)
  const [alert, setAlert] = useState(null)

  function LoginRequest() {
    setAlert(null)
    let payload = {
      Email: email,
      Sifre: password,
    }
    api
      .api()
      .post('ogrenci/Login', payload)
      .then(function (res) {
        if (res.data.success) {
          setRedirect(res.data.success)
        } else {
          setAlert({ typeOfAlert: 'error', title: 'Login', text: res.data.message })
        }
      })
      .catch(function (err) {
        console.log(err)
        setAlert({ typeOfAlert: 'error', title: 'Login', text: err })
      })
  }

  if (redirect) {
    return <Redirect to={`/${role}/Homepage`} />
  }

  return (
    <div className="bg-light min-vh-100 d-flex flex-row align-items-center">
      {alert === null ? null : <Alert props={alert} />}
      <CContainer>
        <CRow className="justify-content-center">
          <CCol md={8}>
            <CCardGroup>
              <CCard className="p-4">
                <CCardBody>
                  <CForm>
                    <h5 style={{ textAlign: 'center' }}>Bakırçay Üniversitesi SKS </h5>
                    <h5 style={{ textAlign: 'center' }}>Randevu Sistemi</h5>
                    <p></p>
                    <CInputGroup className="mb-3">
                      <CInputGroupText>
                        <CIcon icon={cilUser} />
                      </CInputGroupText>
                      <CFormInput
                        placeholder="Email"
                        autoComplete="username"
                        onChange={(e) => setEmail(e.target.value)}
                      />
                    </CInputGroup>
                    <CInputGroup className="mb-4">
                      <CInputGroupText>
                        <CIcon icon={cilLockLocked} />
                      </CInputGroupText>
                      <CFormInput
                        type="password"
                        placeholder="Şifre"
                        autoComplete="current-password"
                        onChange={(e) => setPassword(e.target.value)}
                      />
                    </CInputGroup>
                    <CRow>
                      <CCol xs={6}>
                        <CButton color="info" className="px-4" onClick={() => LoginRequest()}>
                          Giriş Yap
                        </CButton>
                      </CCol>
                    </CRow>
                  </CForm>
                </CCardBody>
              </CCard>
              <CCard
                className="text-white py-5"
                style={{ width: '44%', backgroundColor: '#00a5b5' }}
              >
                <CCardBody className="text-center">
                  <div>
                    <h2>Kayıt Ol</h2>
                    <p>
                      Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
                      tempor incididunt ut labore et dolore magna aliqua.
                    </p>
                    <Link to="/register">
                      <CButton color="danger" className="mt-3" active tabIndex={-1}>
                        Kayıt Ol
                      </CButton>
                    </Link>
                  </div>
                </CCardBody>
              </CCard>
            </CCardGroup>
          </CCol>
        </CRow>
      </CContainer>
    </div>
  )
}

export default Login
