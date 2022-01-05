import React, { useState, useEffect } from 'react'
import {
  CFormSelect,
  CCard,
  CCardBody,
  CCardTitle,
  CCardText,
  CButton,
  CContainer,
  CRow,
  CForm,
  CCol,
} from '@coreui/react'
import DatePicker from 'react-date-picker'
import Alert from '../../../components/Alert/Alert'
import { Redirect } from 'react-router'
import api from '../../../components/Api/Api'

export default function Misafirhane() {
  const [alert, setAlert] = useState(null)
  const [redirect, setRedirect] = useState(200)
  const [date, setDate] = useState(new Date())
  const [refresh, setRefresh] = useState(false)
  const [odaTuru, setOdaTuru] = useState('')

  useEffect(() => {
    setAlert(null)
    let payload = {
      GirisTarihi: date,
    }
    api
      .api()
      .post('misafirhane/MisafirhaneRezervasyonMusaitListele', payload)
      .then(function (res) {
        if (res.data.succes) {
          setGirisTarihi(res.data.data.odaTuru)
        } else {
          setAlert({
            typeOfAlert: 'error',
            title: 'Misafirhane Rezervasyon Oda Listele',
            text: res.data.message,
          })
        }
      })
      .catch(function (err) {
        console.log(err)
        switch (err.response.status) {
          case 401:
            setRedirect(401)
          case 404:
            setRedirect(404)
          case 500:
            setRedirect(500)
          default:
            break
        }
      })
  }, [date, refresh])

  function RezervasyonYap() {
    setAlert(null)
    let payload = {
      GirisTarihi: date,
      OdaTuru: odaTuru,
    }
    api
      .api()
      .post('misafirhane/MisafirhaneRezervasyonYap', payload)
      .then(function (res) {
        if (res.data.success) {
          setAlert({
            typeOfAlert: 'success',
            title: 'Misafirhane Rezervasyon Yap',
            text: res.data.message,
          })
        } else {
          setAlert({
            typeOfAlert: 'error',
            title: 'Misafirhane Rezervasyon Yap',
            text: res.data.message,
          })
        }
      })
      .catch(function (err) {
        console.log(err)
      })
    setRefresh(!refresh)
  }

  if (redirect == 401) {
    return <Redirect to="/Login" />
  } else if (redirect == 404) {
    return <Redirect to="/404" />
  } else if (redirect == 500) {
    return <Redirect to="/500" />
  }

  return (
    <div>
      {alert === null ? null : <Alert props={alert} />}
      <CCard style={{ width: '100%', height: '100%', marginBottom: '60px' }}>
        <CCardBody>
          <CCardTitle style={{ color: '#00a5b5' }}>Misafirhane İçin Rezervasyon</CCardTitle>

          <CCardText>
            Konaklamak için belirlenen ücretler personel ile alt-üst soy aileleri ve öğrenciler için
            geçerlidir.
          </CCardText>
          <CCardText>
            Konaklamalarda 0-6 yaş arası çocuklardan ücret alınmaz. 7-14 yaş için belirlenen ücretin
            yarısı, 15 yaş ve üzeri için tam yatak ücreti alınır.
          </CCardText>
          <CCardText>Odalarda harici kamu kurum personelleri konaklatılmaz.</CCardText>
          <CCardText>
            Üniversite Yönetim Kurulu; Tesislerin ücretlerinde ve kullanım haklarında değişiklik
            yapma hak ve yetkisine sahiptir.
          </CCardText>
        </CCardBody>
      </CCard>

      <div className="d-flex flex-row align-items-center">
        <CContainer>
          <CRow className="justify-content-center">
            <CCol md={6}>
              <CForm>
                <h5 style={{ textAlign: 'center', marginBottom: '25px' }}>
                  Rezervasyon yapmak istediğiniz tarihi seçiniz
                </h5>
                <div style={{ textAlign: 'center', marginBottom: '60px' }}>
                  <DatePicker className="bg-secondary" onChange={setDate} value={date} />
                </div>
                <h5 style={{ textAlign: 'center', marginBottom: '25px' }}>Odanın türünü seçiniz</h5>
                <CFormSelect
                  multiple
                  className="mb-5"
                  onChange={(e) => {
                    setOdaTuru(e.target.value)
                  }}
                >
                  {odaTuru.map((odaTuru) => {
                    return (
                      <option key={odaTuru} style={{ textAlign: 'center' }}>
                        {odaTuru}
                      </option>
                    )
                  })}
                </CFormSelect>
                <CRow>
                  <div style={{ textAlign: 'center' }}>
                    <CButton
                      color="info"
                      className="px-4"
                      onClick={() => {
                        RezervasyonYap()
                        setRefresh(!refresh)
                      }}
                    >
                      REZERVASYON YAP
                    </CButton>
                  </div>
                </CRow>
              </CForm>
            </CCol>
          </CRow>
        </CContainer>
      </div>
    </div>
  )
}
