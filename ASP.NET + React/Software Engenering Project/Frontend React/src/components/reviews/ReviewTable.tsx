import {RouteComponentProps, withRouter} from "react-router";
import React, {useEffect, useState} from "react";
import axios from 'axios';
import {Fab, Grid, Tooltip} from "@material-ui/core";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import TableCell from "@material-ui/core/TableCell";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import {GetArticleDtoResponse} from "../../api/Models/dto/dto";
import Button from "@material-ui/core/Button";
import EditIcon from '@material-ui/icons/Edit';
import AddIcon from '@material-ui/icons/Add';

type Props = RouteComponentProps & {}
const ReviewTable = (props: Props) => {
  const [data, setData] = useState<GetArticleDtoResponse[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      const result = await axios('/api/Articles/preview');
      setData(result.data);
    };

    fetchData();
  }, []);

  const handleArticleReview = (rowData: GetArticleDtoResponse) => {
    props.history.push(`/${rowData.id}`);
  };

  return (
    <Grid>
      <Table stickyHeader aria-label="sticky table">
        <TableHead>
          <TableRow>
            <TableCell>Author</TableCell>
            <TableCell>Title</TableCell>
            <TableCell>Category</TableCell>
            <TableCell>CreatedAt</TableCell>
            <TableCell>Actions</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {data
            .map(row => {
              return (
                <TableRow>
                  <TableCell>
                    {row.author}
                  </TableCell>
                  <TableCell>
                    {row.title}
                  </TableCell>
                  <TableCell>
                    {row.category}
                  </TableCell>
                  <TableCell>
                    {row.createdAt}
                  </TableCell>
                  <TableCell>
                    <Tooltip title="Review Article">
                      <Fab color="primary" size='small'
                      onClick={()=> handleArticleReview(row)}
                      >
                        <EditIcon/>
                      </Fab>
                    </Tooltip>
                  </TableCell>
                </TableRow>
              );
            })}
        </TableBody>
      </Table>
      <Button
        startIcon={<AddIcon/>}
        //onClick={}
      >
        Add Review
      </Button>
    </Grid>
  )

}
export default withRouter(ReviewTable);