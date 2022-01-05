import React, { useState } from 'react'
import {
  CTable,
  CTableBody,
  CTableHead,
  CTableHeaderCell,
  CTableDataCell,
  CTableRow,
  CFormCheck,
  CButton,
} from '@coreui/react'
import CIcon from '@coreui/icons-react'
import { cilFolderOpen, cilFile, cilTrash } from '@coreui/icons'
import { Link } from 'react-router-dom'

export default function SporTesisleriHistory() {
  const [folders, setFolders] = useState([
    {
      folderId: 1,
      isFile: true,
      folderName: 'baba',
      fileKind: 'baba',
      fileSize: 'baba',
      creationDate: 'baba',
    },
    {
      folderId: 2,
      isFile: false,
      folderName: 'baba',
      fileKind: 'baba',
      fileSize: 'baba',
      creationDate: 'baba',
    },
    {
      folderId: 3,
      isFile: true,
      folderName: 'baba',
      fileKind: 'baba',
      fileSize: 'baba',
      creationDate: 'baba',
    },
    {
      folderId: 4,
      isFile: true,
      folderName: 'baba',
      fileKind: 'baba',
      fileSize: 'baba',
      creationDate: 'baba',
    },
  ])

  return (
    <div>
      <CTable striped hover>
        <CTableHead>
          <CTableRow>
            <CTableHeaderCell scope="col" onClick={() => {}}>
              REZERVASYON TARİHİ
            </CTableHeaderCell>
            <CTableHeaderCell scope="col" onClick={() => {}}>
              TESİS TÜRÜ
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
          {folders.map((folder) => {
            return (
              <CTableRow key={folder.folderId} folderid={folder.folderId}>
                <CTableHeaderCell>
                  <CIcon icon={folder.isFile ? cilFile : cilFolderOpen} size="xl" />
                </CTableHeaderCell>
                <CTableDataCell>{folder.folderName}</CTableDataCell>
                <CTableDataCell>{folder.fileSize}</CTableDataCell>
                <CTableDataCell>
                  <CButton color="info" className="px-4">
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
