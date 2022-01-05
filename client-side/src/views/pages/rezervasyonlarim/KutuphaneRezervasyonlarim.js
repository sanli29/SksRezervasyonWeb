import React, { useState, useEffect } from 'react'
import {
  CTable,
  CTableBody,
  CTableHead,
  CTableHeaderCell,
  CTableDataCell,
  CTableRow,
  CButton,
} from '@coreui/react'
import CIcon from '@coreui/icons-react'
import { cilTrash } from '@coreui/icons'
import Alert from '../../../components/Alert/Alert'
import { Redirect } from 'react-router'
import api from '../../../components/Api/Api'

export default function KutuphaneHistory() {
  const [rezervasyonlar, setRezervasyonlar] = useState([])
  const [redirect, setRedirect] = useState(200)
  const [refresh, setRefresh] = useState(false)
  const [alert, setAlert] = useState(null)

  useEffect(() => {
    setAlert(null)
    let payload = {}
    api
      .api()
      .post('Kutuphane/KutuphaneRezervasyonListele', payload)
      .then(function (res) {
        if (res.data.success) {
          setRezervasyonlar(res.data.data)
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
  }, [refresh])

  function RezervasyonIptal(id) {
    setAlert(null)
    let payload = {
      KutuphaneId: id,
    }
    api
      .api()
      .post('Kutuphane/KutuphaneRezervasyonIptal', payload)
      .then(function (res) {
        if (res.data.success) {
          setAlert({ typeOfAlert: 'success', title: 'Iptal', text: res.data.message })
        } else {
          setAlert({ typeOfAlert: 'error', title: 'Iptal', text: res.data.message })
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
      <CTable striped hover>
        <CTableHead>
          <CTableRow>
            <CTableHeaderCell scope="col" onClick={() => {}}>
              REZERVASYON TARİHİ
            </CTableHeaderCell>
            <CTableHeaderCell scope="col" onClick={() => {}}>
              ODA
            </CTableHeaderCell>
            <CTableHeaderCell scope="col" onClick={() => {}}>
              SAAT
            </CTableHeaderCell>
            <CTableHeaderCell scope="col" onClick={() => {}}>
              İPTAL
            </CTableHeaderCell>
          </CTableRow>
        </CTableHead>
        <CTableBody>
          {rezervasyonlar.map((rezervasyon) => {
            return (
              <CTableRow key={rezervasyon.kutuphaneId}>
                <CTableHeaderCell>{rezervasyon.tarih}</CTableHeaderCell>
                <CTableDataCell>{rezervasyon.odaNo}</CTableDataCell>
                <CTableDataCell>{rezervasyon.baslangicSaati}</CTableDataCell>
                <CTableDataCell>
                  <CButton
                    color="info"
                    className="px-4"
                    onClick={() => {
                      RezervasyonIptal(rezervasyon.kutuphaneId)
                      setRefresh(!refresh)
                    }}
                  >
                    <CIcon icon={cilTrash}></CIcon>
                  </CButton>
                </CTableDataCell>
              </CTableRow>
            )
          })}
        </CTableBody>
      </CTable>
    </div>
  )
}
