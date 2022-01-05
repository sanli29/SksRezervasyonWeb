import React, { useState } from 'react'
import {
  CButton,
  CCard,
  CCardBody,
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
import { Link } from 'react-router-dom'
import Alert from '../../../components/Alert/Alert'
import { Redirect } from 'react-router'
import api from '../../../components/Api/Api'

const Register = () => {
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [adi, setAdi] = useState('')
  const [redirect, setRedirect] = useState(false)
  const [alert, setAlert] = useState(null)

  function RegisterRequest() {
    setAlert(null)
    let payload = {
      Email: email,
      Sifre: password,
      Adi: adi,
    }
    api
      .api()
      .post('ogrenci/Register', payload)
      .then(function (res) {
        if (res.data.success) {
          setAlert({ typeOfAlert: 'success', title: 'Register', text: res.data.message })
          setRedirect(res.data.success)
        } else {
          setAlert({ typeOfAlert: 'error', title: 'Register', text: res.data.message })
        }
      })
      .catch(function (err) {
        console.log(err)
        setAlert({ typeOfAlert: 'error', title: 'Register', text: err })
      })
  }
  if (redirect) {
    return <Redirect to="/Login" />
  }

  return (
    <div className="bg-light min-vh-100 d-flex flex-row align-items-center">
      {alert === null ? null : <Alert props={alert} />}
      <CContainer>
        <CRow className="justify-content-center">
          <CCol md={9} lg={7} xl={6}>
            <CCard className="mx-4">
              <CCardBody className="p-4">
                <CForm>
                  <h1>Hesap Oluştur</h1>
                  <p></p>
                  <CInputGroup className="mb-3">
                    <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText>
                    <CFormInput
                      placeholder="Öğrenci Adı"
                      autoComplete="name"
                      onChange={(e) => setAdi(e.target.value)}
                    />
                  </CInputGroup>
                  <CInputGroup className="mb-4">
                    <CInputGroupText>
                      <CIcon icon={cilLockLocked} />
                    </CInputGroupText>
                    <CFormInput
                      placeholder="Email"
                      autoComplete="username"
                      onChange={(e) => setEmail(e.target.value)}
                    />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CInputGroupText>
                      <CIcon icon={cilLockLocked} />
                    </CInputGroupText>
                    <CFormInput
                      type="password"
                      placeholder="Şifre"
                      autoComplete="new-password"
                      onChange={(e) => setPassword(e.target.value)}
                    />
                  </CInputGroup>
                  <div className="text-center">
                    <CButton
                      color="info"
                      onClick={() => {
                        RegisterRequest()
                      }}
                    >
                      Hesap Oluştur
                    </CButton>
                    <Link to="/Login">
                      <CButton style={{ marginLeft: '20px' }} color="success">
                        Zaten bir hesabınız var mı?
                      </CButton>
                    </Link>
                  </div>
                </CForm>
              </CCardBody>
            </CCard>
          </CCol>
        </CRow>
      </CContainer>
    </div>
  )
}

export default Register
