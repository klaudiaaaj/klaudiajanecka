import React, {useState} from "react";
import {Document, Page, pdfjs} from "react-pdf";
import {
  Container,
  makeStyles,
  Theme,
  createStyles, Grid,
} from "@material-ui/core";
import Button from '@material-ui/core/Button';
import Slide from '@material-ui/core/Slide';
import {TransitionProps} from '@material-ui/core/transitions';

pdfjs.GlobalWorkerOptions.workerSrc = `//cdnjs.cloudflare.com/ajax/libs/pdf.js/${pdfjs.version}/pdf.worker.js`;

type Props = {
  open: boolean;
  file: string;
  close: () => void;
}

function PdfView(props: Props) {
  const [open, setOpen] = React.useState(false);
  const [numPages, setNumPages] = useState<number>(0);
  const [pageNumber, setPageNumber] = useState(0);
  const [scale, setScale] = useState(1.5);

  const useStyles = makeStyles((theme: Theme) =>
    createStyles({
      root: {
        "& > *": {
          margin: theme.spacing(1),
        },
        appBar: {
          position: 'relative',
        },
        title: {
          marginLeft: theme.spacing(2),
          flex: 1,
        },
      },
    })
  );

  const classes = useStyles();

  function PreviousPage() {
    if (pageNumber > 1) setPageNumber(pageNumber - 1);
  }

  function NextPage() {
    if (pageNumber < numPages) setPageNumber(pageNumber + 1);
  }

  function onDocumentLoadSuccess(pdf: pdfjs.PDFDocumentProxy) {
    setPageNumber(1);
    setNumPages(pdf.numPages);
  }

  function zoomIn() {
    if (scale < 2.5) setScale(scale + 0.25);
  }

  function zoomOut() {
    if (scale > 0.5) setScale(scale - 0.25);
  }

  const handleOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setNumPages(0);
    setPageNumber(0);
    setOpen(false);
  };
  const Transition = React.forwardRef(function Transition(
    props: TransitionProps & { children?: React.ReactElement },
    ref: React.Ref<unknown>,
  ) {
    return <Slide direction="up" ref={ref} {...props} />;
  });

  const body = (
    <Grid>
      <div>
        <h1>
          {("Page")}: {pageNumber} {("Of")} {numPages}
        </h1>
        <Button variant="contained" color="primary" onClick={PreviousPage}>
          {("Previous")}
        </Button>
        <Button variant="contained" color="primary" onClick={NextPage}>
          {("Next")}
        </Button>
        <Button variant="contained" color="primary" onClick={zoomOut}>
          {("ZoomOut")}
        </Button>
        <Button variant="contained" color="primary" onClick={zoomIn}>
          {("ZoomIn")}
        </Button>
        <Button variant="contained" color="primary" onClick={handleClose}>
          {("Exit")}
        </Button>
      </div>
      <Document file={props.file} onLoadSuccess={onDocumentLoadSuccess}>
        <Page pageNumber={pageNumber} scale={scale}/>
      </Document>
    </Grid>
  );
  return <div>{body}</div>;
}

export default PdfView;
