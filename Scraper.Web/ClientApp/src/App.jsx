import React, { useState, useEffect } from 'react';
import axios from 'axios';


const App = () => {

    const [lessonsByMonth, setLessonsByMonth] = useState([]);

    useEffect(() => {
        const getData = async () => {
            const { data } = await axios.get('/api/scraper/scrape');
            setLessonsByMonth(data);
        }
        getData();

    }, [])

    const splitUl = ul => {
        const liArray = ul.split('\n').slice(1, -1)
        return liArray.map((l) =>
            <li key={l}>{l}</li>
        )
    }

    return (
        <div className='container mt-5'>
            <div>
                <h2>COURSE CURRICULUM</h2>
            </div>
            <table style={{ fontSize: 20 }} className="table table-bordered">
                <tbody>
                    {lessonsByMonth.map(i => {
                        return <tr key={i.month}>
                            <td style={{ verticalAlign: "middle" }}>{i.month}</td>
                            <td>
                                <ul>
                                    {splitUl(i.ul)}
                                </ul>
                            </td>
                        </tr>
                    }
                    )}
                </tbody>
            </table>
        </div>
    )
}

export default App;