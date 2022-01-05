import React, { useState, useEffect } from 'react'
import {
  CCard,
  CCardBody,
  CCardTitle,
  CCardText,
  CFormSelect,
  CButton,
  CContainer,
  CRow,
  CForm,
  CCol,
} from '@coreui/react'
import { Link } from 'react-router-dom'
import DatePicker from 'react-date-picker'
import Alert from '../../../components/Alert/Alert'
import { Redirect } from 'react-router'
import api from '../../../components/Api/Api'

export default function Kutuphane() {
  const [alert, setAlert] = useState(null)
  const [redirect, setRedirect] = useState(200)
  const [date, setDate] = useState(new Date())
  const [odaNo, setOdaNo] = useState(1)
  const [baslangicSaati, setBaslangicSaati] = useState([])
  const [saat, setSaat] = useState('')
  const [refresh, setRefresh] = useState(false)

  useEffect(() => {
    setAlert(null)
    let payload = {
      Tarih: date,
      OdaNo: odaNo,
    }
    api
      .api()
      .post('Kutuphane/KutuphaneRezervasyonMusaitListele', payload)
      .then(function (res) {
        if (res.data.success) {
          setBaslangicSaati(res.data.data.baslangicSaati)
        } else {
          setAlert({
            typeOfAlert: 'error',
            title: 'Kutuphane Rezervasyon Listele',
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
  }, [date, odaNo, refresh])

  function RezervasyonYap() {
    setAlert(null)
    let payload = {
      Tarih: date,
      OdaNo: odaNo,
      BaslangicSaati: saat,
    }
    api
      .api()
      .post('Kutuphane/KutuphaneRezervasyonYap', payload)
      .then(function (res) {
        if (res.data.success) {
          setAlert({
            typeOfAlert: 'success',
            title: 'Kutuphane Rezervasyon Yap',
            text: res.data.message,
          })
        } else {
          setAlert({
            typeOfAlert: 'error',
            title: 'Kutuphane Rezervasyon Yap',
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
      <CCard style={{ width: '100%', height: '100%', marginBottom: '20px' }}>
        <CCardBody>
          <CCardTitle style={{ color: '#00a5b5' }}>Kütüphane İçin Rezervasyon</CCardTitle>
          <CCardText>
            Üniversite kütüphanemiz 998 metrekare alanda 300 kişi oturma kapasitesine sahiptir.
            Kütüphanemizde 43.466 basılı kitap, 13.895 e-kitap, 7.475 süreli yayın ve 970 görsel
            yayın bulunmaktadır. Kitapların içerikleri hukuk, mühendislik, iktisat, işletme,
            bilişim, sosyal ve beşeri bilimler (coğrafya edebiyat, psikoloji, sosyoloji) sağlık, dil
            bilimleri alanlarında olup Üniversite öğrencilerinin birincil düzeyde yararlanabileceği
            içeriğe sahiptir.
          </CCardText>
          <CCardText>Kütüphane çalışma Odalarında sessiz olunmaya dikkat edilmelidir.</CCardText>
          <CCardText>Kütüphane içerisinde yiyecek, içecek ve sigara tüketilemez</CCardText>
        </CCardBody>
      </CCard>

      <div className="d-flex flex-row align-items-center">
        <CContainer>
          <CRow className="justify-content-center">
            <CCol md={6}>
              <CForm>
                <h5 style={{ textAlign: 'center', marginBottom: '20px' }}>
                  Rezervasyon yapmak istediğiniz tarihi seçiniz
                </h5>
                <div style={{ textAlign: 'center', marginBottom: '40px' }}>
                  <DatePicker className="bg-secondary" onChange={setDate} value={date} />
                </div>
                <h5 style={{ textAlign: 'center', marginBottom: '20px' }}>
                  Grup çalışma odası seçiniz
                </h5>
                <CFormSelect
                  className="mb-4"
                  aria-label="Default select example"
                  onChange={(e) => {
                    setOdaNo(e.target.value)
                  }}
                >
                  <option style={{ textAlign: 'center' }} value="1">
                    Oda-1
                  </option>
                  <option style={{ textAlign: 'center' }} value="2">
                    Oda-2
                  </option>
                  <option style={{ textAlign: 'center' }} value="3">
                    Oda-3
                  </option>
                </CFormSelect>

                <h5 style={{ textAlign: 'center', marginBottom: '20px' }}>Saat seçiniz </h5>
                <CFormSelect
                  multiple
                  htmlSize={5}
                  className="mb-4"
                  aria-label="Default select example"
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
