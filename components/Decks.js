import React, { Component } from 'react';
import { StyleSheet, View, Text } from 'react-native';
import { purple, white } from '../utils/colors';
import DeckItem from './DeckItem';

class Decks extends Component {
	showDetail = () => {
		this.props.navigation.navigate('DeckDetail');
	};
	render() {
		return (
			<View style={styles.container}>
				<View style={styles.column}>
					<DeckItem showDetail={this.showDetail} />
				</View>
			</View>
		);
	}
}

const styles = StyleSheet.create({
	container: {
		flex: 1,
		padding: 20,
		backgroundColor: white
	},
	column: {
		flexDirection: 'column',
		flex: 1,
		alignItems: 'center'
	}
});
export default Decks;
