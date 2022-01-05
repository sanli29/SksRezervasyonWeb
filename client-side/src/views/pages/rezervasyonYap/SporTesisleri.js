import React, { useState, useEffect } from 'react'
import {
  CCard,
  CCardBody,
  CCardTitle,
  CCardText,
  CFormSelect,
  CButton,
  CContainer,
  CForm,
  CRow,
  CCol,
} from '@coreui/react'
import DatePicker from 'react-date-picker'
import Alert from '../../../components/Alert/Alert'
import { Redirect } from 'react-router'
import api from '../../../components/Api/Api'

export default function SporTesisleri() {
  const [date, setDate] = useState(new Date())
  const [alert, setAlert] = useState(null)
  const [redirect, setRedirect] = useState(200)
  const [tesisTur, setTesisTur] = useState(1)
  const [baslangicSaati, setBaslangicSaati] = useState([])
  const [saat, setSaat] = useState('')
  const [refresh, setRefresh] = useState(false)

  useEffect(() => {
    setAlert(null)
    let payload = {
      Tarih: date,
      TesisTur: tesisTur,
    }
    api
      .api()
      .post('tesi/TesiRezervasyonMusaitListele', payload)
      .then(function (res) {
        if (res.data.success) {
          setBaslangicSaati(res.data.data.baslangicSaati)
        } else {
          setAlert({
            typeOfAlert: 'error',
            title: 'Spor Tesisleri Rezervasyon Listele',
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
  }, [date, tesisTur, refresh])

  function RezervasyonYap() {
    setAlert(null)
    let payload = {
      Tarih: date,
      TesisTur: tesisTur,
      BaslangicSaati: saat,
    }
    api
      .api()
      .post('tesi/TesiRezervasyonYap', payload)
      .then(function (res) {
        if (res.data.success) {
          setAlert({
            typeOfAlert: 'success',
            title: 'Spor Tesisleri Rezervasyon Yap',
            text: res.data.message,
          })
        } else {
          setAlert({
            typeOfAlert: 'error',
            title: 'Spor Tesisleri Rezervasyon Yap',
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
      <CCard style={{ width: '100%', height: '100%', marginBottom: '30px' }}>
        <CCardBody>
          <CCardTitle style={{ color: '#00a5b5' }}>Spor Tesisleri İçin Rezervasyon</CCardTitle>
          <CCardText>
            Tesisler için tespit edilen ücretler, tahsisin yapıldığı tarihte ilgililerden peşin
            olarak tahsil edilir.
          </CCardText>
          <CCardText>
            Kurum dışı ve özel talep kullanımları üniversite yönetiminin onayı ile gerçekleşebilir.
          </CCardText>
          <CCardText>Tesislere, spora uygun olmayan ayakkabı ve kıyafetler ile girilmez.</CCardText>
        </CCardBody>
      </CCard>

      <div className="d-flex flex-row align-items-center">
        <CContainer>
          <CRow className="justify-content-center">
            <CCol md={6}>
              <CForm>
                <h5 style={{ textAlign: 'center', marginBottom: '25px' }}>
                  Rezervasyon yapmak istediğiniz tesisi seçiniz
                </h5>
                <CFormSelect
                  className="mb-4"
                  onChange={(e) => {
                    setTesisTur(e.target.value)
                  }}
                >
                  <option style={{ textAlign: 'center' }} value="1">
                    Halısaha
                  </option>
                  <option style={{ textAlign: 'center' }} value="2">
                    Tenis Kortu
                  </option>
                  <option style={{ textAlign: 'center' }} value="3">
                    Basketbol Sahası
                  </option>
                </CFormSelect>
                <h5 style={{ textAlign: 'center', marginBottom: '25px' }}>Tarih seçiniz </h5>
                <div style={{ textAlign: 'center', marginBottom: '50px' }}>
                  <DatePicker className="bg-secondary" onChange={setDate} value={date} />
                </div>
                <h5 style={{ textAlign: 'center', marginBottom: '25px' }}>Saat seçiniz </h5>
                <CFormSelect
                  multiple
                  htmlSize={5}
                  className="mb-4"
                  onChange={(e) => {
                    setSaat(e.target.value)
                  }}
                >
                  {baslangicSaati.map((saat) => {
                    return (
                      <option key={saat} style={{ textAlign: 'center' }}>
                        {saat}
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
