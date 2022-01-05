import React, { useState, useEffect } from 'react'
import {
  CTable,
  CTableBody,
  CTableHead,
  CTableHeaderCell,
  CTableDataCell,
  CTableRow,
  CCard,
  CCardBody,
  CCardTitle,
  CCardText,
  CButton,
} from '@coreui/react'
import CIcon from '@coreui/icons-react'
import { cilCheckAlt } from '@coreui/icons'
import Alert from '../../../components/Alert/Alert'
import { Redirect } from 'react-router'
import api from '../../../components/Api/Api'

export default function Yemekhane() {
  const [rezervasyonlar, setRezervasyonlar] = useState([])
  const [alert, setAlert] = useState(null)
  const [redirect, setRedirect] = useState(200)
  const [refresh, setRefresh] = useState(false)

  useEffect(() => {
    setAlert(null)
    let payload = {}
    api
      .api()
      .post('yemekhane/YemekhaneRezervasyonMusaitListele', payload)
      .then(function (res) {
        if (res.data.success) {
          setRezervasyonlar(res.data.data)
        } else {
          setAlert({
            typeOfAlert: 'error',
            title: 'Yemekhane Rezervasyon Listele',
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
  }, [refresh])

  function RezervasyonYap(tarih, fiyat, ogun) {
    setAlert(null)
    let payload = {
      tarih: tarih,
      fiyat: fiyat,
      ogun: ogun,
    }
    api
      .api()
      .post('yemekhane/YemekhaneRezervasyonYap', payload)
      .then(function (res) {
        if (res.data.success) {
          setAlert({
            typeOfAlert: 'success',
            title: 'Yemekhane Rezervasyon Yap',
            text: res.data.message,
          })
        } else {
          setAlert({
            typeOfAlert: 'error',
            title: 'Yemekhane Rezervasyon Yap',
            text: res.data.message,
          })
        }
      })
      .catch(function (err) {
        console.log(err)
      })
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
          <CCardTitle style={{ color: '#00a5b5' }}>Yemekhane İçin Rezervasyon</CCardTitle>
          <CCardText>
            İzmir Bakırçay Üniversitesi Sağlık Kültür ve Spor Daire Başkanlığı olarak, Üniversitemiz
            öğrenci ve personeline kaliteli yemek çıkarılmasını sağlayarak, beslenme ile ilgili
            problemlerin çözümlenmesini ve denetlenmesini sağlamak üzere kendi mutfağımızda öğrenci
            ve personellerimize yemekhane hizmeti vermekteyiz.
          </CCardText>
          <CCardText>
            Tüm üretim faaliyetlerimiz yerleşke içerisinde yemekhanemizde yapılmaktadır.
          </CCardText>
          <CCardText>
            Yemek hizmeti, öğrencilerin ve personelin sahip olduğu çipli kartlara, yemek satış
            noktalarından gerçekleştirilmektedir.
          </CCardText>
        </CCardBody>
      </CCard>

      <CTable striped hover>
        <CTableHead>
          <CTableRow>
            <CTableHeaderCell scope="col">REZERVASYON TARİHİ</CTableHeaderCell>
            <CTableHeaderCell scope="col">ÖĞÜN</CTableHeaderCell>
            <CTableHeaderCell scope="col">FİYAT</CTableHeaderCell>
            <CTableHeaderCell scope="col">Rezervasyon Yap</CTableHeaderCell>
          </CTableRow>
        </CTableHead>
        <CTableBody>
          {rezervasyonlar.map((rezervasyon) => {
            return (
              <CTableRow key={rezervasyon.yemekhaneId}>
                <CTableHeaderCell>{rezervasyon.tarih}</CTableHeaderCell>
                <CTableDataCell>{rezervasyon.ogun}</CTableDataCell>
                <CTableDataCell>{rezervasyon.fiyat}</CTableDataCell>
                <CTableHeaderCell>
                  <CButton
                    color="info"
                    className="px-3"
                    onClick={() => {
                      RezervasyonYap(rezervasyon.tarih, rezervasyon.fiyat, rezervasyon.ogun)
                      setRefresh(!refresh)
                    }}
                  >
                    <CIcon icon={cilCheckAlt}></CIcon>
                  </CButton>
                </CTableHeaderCell>
              </CTableRow>
            )
          })}
        </CTableBody>
      </CTable>
    </div>
  )
}
