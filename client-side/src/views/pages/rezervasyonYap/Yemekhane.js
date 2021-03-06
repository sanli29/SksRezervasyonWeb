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
          <CCardTitle style={{ color: '#00a5b5' }}>Yemekhane ????in Rezervasyon</CCardTitle>
          <CCardText>
            ??zmir Bak??r??ay ??niversitesi Sa??l??k K??lt??r ve Spor Daire Ba??kanl?????? olarak, ??niversitemiz
            ????renci ve personeline kaliteli yemek ????kar??lmas??n?? sa??layarak, beslenme ile ilgili
            problemlerin ????z??mlenmesini ve denetlenmesini sa??lamak ??zere kendi mutfa????m??zda ????renci
            ve personellerimize yemekhane hizmeti vermekteyiz.
          </CCardText>
          <CCardText>
            T??m ??retim faaliyetlerimiz yerle??ke i??erisinde yemekhanemizde yap??lmaktad??r.
          </CCardText>
          <CCardText>
            Yemek hizmeti, ????rencilerin ve personelin sahip oldu??u ??ipli kartlara, yemek sat????
            noktalar??ndan ger??ekle??tirilmektedir.
          </CCardText>
        </CCardBody>
      </CCard>

      <CTable striped hover>
        <CTableHead>
          <CTableRow>
            <CTableHeaderCell scope="col">REZERVASYON TAR??H??</CTableHeaderCell>
            <CTableHeaderCell scope="col">??????N</CTableHeaderCell>
            <CTableHeaderCell scope="col">F??YAT</CTableHeaderCell>
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
