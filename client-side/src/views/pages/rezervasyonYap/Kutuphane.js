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
          <CCardTitle style={{ color: '#00a5b5' }}>K??t??phane ????in Rezervasyon</CCardTitle>
          <CCardText>
            ??niversite k??t??phanemiz 998 metrekare alanda 300 ki??i oturma kapasitesine sahiptir.
            K??t??phanemizde 43.466 bas??l?? kitap, 13.895 e-kitap, 7.475 s??reli yay??n ve 970 g??rsel
            yay??n bulunmaktad??r. Kitaplar??n i??erikleri hukuk, m??hendislik, iktisat, i??letme,
            bili??im, sosyal ve be??eri bilimler (co??rafya edebiyat, psikoloji, sosyoloji) sa??l??k, dil
            bilimleri alanlar??nda olup ??niversite ????rencilerinin birincil d??zeyde yararlanabilece??i
            i??eri??e sahiptir.
          </CCardText>
          <CCardText>K??t??phane ??al????ma Odalar??nda sessiz olunmaya dikkat edilmelidir.</CCardText>
          <CCardText>K??t??phane i??erisinde yiyecek, i??ecek ve sigara t??ketilemez</CCardText>
        </CCardBody>
      </CCard>

      <div className="d-flex flex-row align-items-center">
        <CContainer>
          <CRow className="justify-content-center">
            <CCol md={6}>
              <CForm>
                <h5 style={{ textAlign: 'center', marginBottom: '20px' }}>
                  Rezervasyon yapmak istedi??iniz tarihi se??iniz
                </h5>
                <div style={{ textAlign: 'center', marginBottom: '40px' }}>
                  <DatePicker className="bg-secondary" onChange={setDate} value={date} />
                </div>
                <h5 style={{ textAlign: 'center', marginBottom: '20px' }}>
                  Grup ??al????ma odas?? se??iniz
                </h5>
                <CFormSelect
                  className="mb-4"
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

                <h5 style={{ textAlign: 'center', marginBottom: '20px' }}>Saat se??iniz </h5>
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
