import React, {useEffect, useState} from 'react';
import {getArticlesByAuthorId} from '../../api/articles';
import Grid from "@material-ui/core/Grid"
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import TableCell from "@material-ui/core/TableCell";
import TableBody from "@material-ui/core/TableBody";
import Table from "@material-ui/core/Table";
import Moment from 'react-moment';
import Button from "@material-ui/core/Button"
import {RouteComponentProps, withRouter} from "react-router";
import {MyArticleResponse, Status} from "../../api/Models/dto/dto";
import {getArticleFile} from "../../api/articles";
import PdfView from '../articleFile/pdfViwer';
import {Paper, TableContainer} from "@material-ui/core";
import {makeStyles} from "@material-ui/core/styles";

type Props = RouteComponentProps & {}
const Articles = (props: Props) => {

    const [articles, setArticles] = useState<MyArticleResponse[]>([]);
    const [file, setFile] = useState<string>("");
    const [pdfViwer, setPdfViwer] = useState<boolean>(false);
    const [articleId, setArticleId] = useState<number>(0);

    useEffect(() => {
        async function fetchData() {
            // Hardcoded for now as I'm not sure if the author data structure exists
            const stat = await getArticlesByAuthorId(4);
            setArticles(stat);
        }

        fetchData();
    }, []);

    async function ViewFile(id: number) {
        getArticleFile(id)
            .then((resp) => {
                setFile(resp);
            })
    }

    const closePdfViewer = () => {
        setPdfViwer(false);
        setFile("");
    };
    const onClickViewPdf = (id: number) => {
        ViewFile(id);
        setPdfViwer(true);
    }
    const classes = useStyles();
    return (
        <Grid>
            <TableContainer component={Paper}>
                <Table>
                    <TableHead className={classes.header}>
                        <TableRow >
                            <TableCell>Title</TableCell>
                            <TableCell>Status</TableCell>
                            <TableCell>Created date</TableCell>
                            <TableCell>Actions</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {articles
                            .map(row => {
                                return (
                                    <TableRow>
                                        <TableCell > {row.title} </TableCell>
                                        <TableCell> {Status[row.status]} </TableCell>
                                        <TableCell>
                                            <Moment date={row.createdAt} format="DD.MM.YYYY"/>
                                        </TableCell>
                                        <TableCell className={classes.cell_short}>
                                            <Button variant="contained"
                                                    color="primary"
                                                    onClick={() => ViewFile(row.articleFileId)}
                                            >
                                                View Article
                                            </Button>
                                        </TableCell>
                                    </TableRow>
                                );
                            })}
                    </TableBody>
                </Table>
            </TableContainer>
            <PdfView
                open={pdfViwer}
                file={file}
                close={closePdfViewer}
            />
        </Grid>
    )
}

const useStyles = makeStyles( {
    header: {
        backgroundColor: '#ADD8E6'
    },
    cell_medium: {
        fontSize: "10px",
        width: 250,
        minWidth: 1,
    },
    cell_short: {
        fontSize: "10px",
        width: 170,
    },

});
export default withRouter(Articles);